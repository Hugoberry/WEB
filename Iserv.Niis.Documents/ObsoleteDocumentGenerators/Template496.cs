﻿using System.Collections.Generic;
using Iserv.Niis.Common.Codes;
using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.Documents.UserInput.Abstract;
using Iserv.Niis.FileConverter.Abstract;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;
using TemplateEngine.Docx;

namespace Iserv.Niis.Documents.ObsoleteDocumentGenerators
{
    //[DocumentGenerator(3851, DicDocumentTypeCodes.OUT_UV_Pol_Reg_TZ_AP_sov_v1_19)]
    [DocumentGenerator(3851, DicDocumentTypeCodes.NotificationOfTmRegistration)]
    public class Template496 : DocumentGeneratorBase
    {
        public Template496(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor,
            templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return new Content(
                BuildField(TemplateFieldName.CurrentUser),
                BuildField(TemplateFieldName.Disclaimer),
                BuildImage(TemplateFieldName.Image),
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.Icgs511),
                BuildField(TemplateFieldName.Priority31),
                BuildField(TemplateFieldName.Priority32),
                BuildField(TemplateFieldName.Priority33),
                BuildField(TemplateFieldName.Declarants),
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.CorrespondenceContact),
                BuildField(TemplateFieldName.CurrentYear),
                BuildField(TemplateFieldName.Colors),
                BuildField(TemplateFieldName.ApplicantAddress));
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] {"RequestId", "UserId", DocumentGeneratorBase.UserInputFieldsParameterName};
        }
    }
}