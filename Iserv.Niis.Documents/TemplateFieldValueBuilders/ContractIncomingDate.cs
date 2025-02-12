﻿using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.DocumentsBusinessLogic.Contracts;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;
using System.Collections.Generic;

namespace Iserv.Niis.Documents.TemplateFieldValueBuilders
{
    [TemplateFieldName(TemplateFieldName.ContractIncomingDate)]
    internal class ContractIncomingDate : TemplateFieldValueBase
    {
        public ContractIncomingDate(IExecutor executor) : base(executor)
        {

        }
        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] { "RequestId" };
        }
        protected override dynamic GetInternal(Dictionary<string, object> parameters)
        {
            var contract = Executor.GetQuery<GetContractByIdQuery>().Process(q => q.Execute((int)parameters["RequestId"]));
            return contract?.IncomingDate?.ToString("dd.MM.yyyy") ?? string.Empty;
        }
    }
}
