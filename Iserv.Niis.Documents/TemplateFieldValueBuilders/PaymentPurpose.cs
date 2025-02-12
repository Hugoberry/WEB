﻿using System.Collections.Generic;
using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.Model.Models.PaymentsJournal;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;

namespace Iserv.Niis.Documents.TemplateFieldValueBuilders
{
    /// <summary>
    /// Назначение платежа.
    /// </summary>
    [TemplateFieldName(TemplateFieldName.PaymentPurpose)]
    public class PaymentPurpose : TemplateFieldValueBase
    {
        public PaymentPurpose(IExecutor executor) : base(executor)
        {
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] { "PaymentUse" };
        }

        protected override dynamic GetInternal(Dictionary<string, object> parameters)
        {
            PaymentUseDto paymentUse = parameters["PaymentUse"] as PaymentUseDto;

            if (paymentUse is null)
            {
                return string.Empty;
            }

            return paymentUse.PaymentPurpose ?? string.Empty;
        }
    }
}
