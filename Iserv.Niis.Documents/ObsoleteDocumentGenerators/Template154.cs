﻿using System.Collections.Generic;
using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.Documents.UserInput.Abstract;
using Iserv.Niis.FileConverter.Abstract;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;
using TemplateEngine.Docx;

namespace Iserv.Niis.Documents.ObsoleteDocumentGenerators
{
    [DocumentGenerator(2692, "IZ-3B-KZ")]
    public class Template154 : DocumentGeneratorBase
    {
        public Template154(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor,
            templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return new Content(
                BuildField(TemplateFieldName.CurrentUser),
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.CorrespondenceContact),
                BuildField(TemplateFieldName.RequestNameRu),
                BuildField(TemplateFieldName.Authors),
                BuildField(TemplateFieldName.RequestDateCreate),
                BuildField(TemplateFieldName.Declarants),
                BuildField(TemplateFieldName.IpcCodes),
                BuildField(TemplateFieldName.RequestNameKz),
                BuildField(TemplateFieldName.NumberApxWork),
                BuildField(TemplateFieldName.TransferDateWithCode),
                BuildField(TemplateFieldName.Priority86WithoutCode),
                BuildField(TemplateFieldName.CurrentYear));
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] {"RequestId"};
        }
    }
}