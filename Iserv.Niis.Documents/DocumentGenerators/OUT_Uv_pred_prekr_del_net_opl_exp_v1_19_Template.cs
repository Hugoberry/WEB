﻿using Iserv.Niis.Common.Codes;
using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.Documents.UserInput.Abstract;
using Iserv.Niis.FileConverter.Abstract;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace Iserv.Niis.Documents.DocumentGenerators
{
    [DocumentGenerator(0, DicDocumentTypeCodes.NotificationOfPaymentlessOfficeWorkTermination)]
    public class OUT_Uv_pred_prekr_del_net_opl_exp_v1_19_Template : DocumentGeneratorBase
    {
        public OUT_Uv_pred_prekr_del_net_opl_exp_v1_19_Template(IExecutor executor,
            ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper)
            : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }
        protected override Content PrepareValue()
        {
            return new Content(
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.Declarants),
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.Icgs511),
                BuildField(TemplateFieldName.Colors)
                );
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] { "RequestId" };
        }
    }
}
