﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iserv.Niis.WorkflowBusinessLogic.Dictionaries.DicRouteStage;
using Iserv.Niis.WorkflowBusinessLogic.WorkflowContracts;
using NetCoreRules;

namespace Iserv.Niis.WorkflowBusinessLogic.RulesContract
{
    public class IsContractExistsPreviousRouteStageByCodeRule: BaseRule<ContractWorkFlowRequest>
    {
        public bool Eval(string currentStageCode, string previousStageCode)
        {
            if (string.IsNullOrEmpty(previousStageCode) == true)
            {
                return false;
            }

            if (string.IsNullOrEmpty(currentStageCode) == true && string.IsNullOrEmpty(previousStageCode) == true)
            {
                return false;
            }

            if (string.IsNullOrEmpty(currentStageCode) == true && string.IsNullOrEmpty(previousStageCode) == false)
            {
                var isPreviousStageHasAny = Executor.GetQuery<GetPreviousDicRouteStageOrdersByCodeQuery>().Process(r => r.Execute(previousStageCode)).Any();

                return isPreviousStageHasAny;
            }

            return true;

            //var stages = Executor.GetQuery<GetPreviousDicRouteStageOrdersByCodeQuery>().Process(r => r.Execute(currentStageCode));

            //if (stages.Any(r => r.CurrentStage != null && r.CurrentStage.Code == previousStageCode))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
