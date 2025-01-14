﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Iserv.Niis.DataAccess.EntityFramework;
using Iserv.Niis.Domain.Entities.Contract;
using Iserv.Niis.Domain.Entities.Dictionaries;
using Iserv.Niis.Workflow.Abstract;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Iserv.Niis.Workflow.Implementations.Contract.Stages.DocumentApplier
{
    public class StageLogic
    {
        private readonly Dictionary<string, Func<Domain.Entities.Contract.Contract, Expression<Func<DicRouteStage, bool>>>> _logicMap;
        private readonly NiisWebContext _context;
        private readonly IWorkflowApplier<Domain.Entities.Contract.Contract> _workflowApplier;

        public StageLogic(
            NiisWebContext context,
            IWorkflowApplier<Domain.Entities.Contract.Contract> workflowApplier)
        {
            _context = context;
            _workflowApplier = workflowApplier;
            _logicMap = new Dictionary<string, Func<Domain.Entities.Contract.Contract, Expression<Func<DicRouteStage, bool>>>>
            {
                { DicDocumentType.Codes.ExtractFromStateRegisterOfTrademark, SubstantiveExaminationLogic },
                { DicDocumentType.Codes.ExtractFromStateRegisterOfSelectiveAchievement, SubstantiveExaminationLogic },
                { DicDocumentType.Codes.ExtractFromStateRegisterOfIndustrialDesign, SubstantiveExaminationLogic },
                { DicDocumentType.Codes.ExtractFromStateRegisterOfInvention, SubstantiveExaminationLogic },
                { DicDocumentType.Codes.ExtractFromStateRegisterOfUsefulModel, SubstantiveExaminationLogic },
                { DicDocumentType.Codes.ExtractFromStateRegisterOfWellKnownTrademark, SubstantiveExaminationLogic },
                { DicDocumentType.Codes.ExtractFromStateRegisterOfCOO, SubstantiveExaminationLogic }
            };
        }

        public async Task ApplyAsync(ContractDocument contractDocument)
        {
            await ApplyStageAsync(
                _logicMap.TryGetValue(contractDocument.Document.Type.Code, out var logic)
                    ? logic.Invoke(contractDocument.Contract)
                    : null, contractDocument.Contract);
        }

        /// <summary>
        /// Логика обработки этапов при входящих документах, выписках из государственного реестра
        /// </summary>
        /// <param name="contract">Договор</param>
        /// <returns>Запрос для получения этапа "Экспертиза по существу"</returns>
        private Expression<Func<DicRouteStage, bool>> SubstantiveExaminationLogic(Domain.Entities.Contract.Contract contract)
        {
            //Ожидается выписка
            if (CurrentStageContains(contract, "DK02.2.0"))
            {
                return s => s.Code.Equals("DK02.4");
            }
            
            return null;
        }


        protected virtual async Task ApplyStageAsync(Expression<Func<DicRouteStage, bool>> nextStageFunc, Domain.Entities.Contract.Contract contract)
        {
            if (nextStageFunc == null)
            {
                return;
            }

            DicRouteStage nextStage;

            try
            {
                nextStage = await _context.DicRouteStages.SingleAsync(nextStageFunc);
            }
            catch (Exception)
            {
                Log.Warning($"Workflow logic applyer. The next stage query is incorrect: {nextStageFunc}!");
                return;
            }

            var workflow = new ContractWorkflow
            {
                RouteId = nextStage.RouteId,
                OwnerId = contract.Id,
                Owner = contract,
                CurrentStageId = nextStage.Id,
                CurrentUserId = contract.CurrentWorkflow.CurrentUserId,
                FromStageId = contract.CurrentWorkflow.CurrentStageId,
                FromUserId = contract.CurrentWorkflow.CurrentUserId,
                IsComplete = nextStage.IsLast,
                IsSystem = nextStage.IsSystem
            };

            await _workflowApplier.ApplyAsync(workflow);
        }

        private bool FromStageContains(Domain.Entities.Contract.Contract contract, params string[] codes)
        {
            return codes.Contains(contract.CurrentWorkflow.FromStage.Code);
        }

        private bool CurrentStageContains(Domain.Entities.Contract.Contract contract, params string[] codes)
        {
            return codes.Contains(contract.CurrentWorkflow.CurrentStage.Code);
        }

        private bool CurrentStageContains(Domain.Entities.Document.Document document, params string[] codes)
        {
            return codes.Contains(document.CurrentWorkflow.CurrentStage.Code);
        }

        private bool AnyDocuments(Domain.Entities.Contract.Contract contract, string documentTypeCode)
        {
            return contract.Documents.Select(rd => rd.Document).Any(d => d.Type.Code.Equals(documentTypeCode));
        }

        private bool AnyDocuments(Domain.Entities.Contract.Contract contract, params string[] documentTypeCodes)
        {
            return contract.Documents.Select(rd => rd.Document).Any(d => documentTypeCodes.Contains(d.Type.Code));
        }

        private bool HasPaidInvoices(Domain.Entities.Contract.Contract contract, params string[] tariffCodes)
        {
            var restorationInvoices = contract.PaymentInvoices
                .Where(pi => tariffCodes.Contains(pi.Tariff.Code)).ToList();
            return restorationInvoices.Any() && restorationInvoices.All(pi => pi.Status.Code != "notpaid");
        }
    }
}
