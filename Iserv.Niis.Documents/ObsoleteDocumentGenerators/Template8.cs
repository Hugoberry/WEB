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
    [DocumentGenerator(122, "IZ-4IP")]
    public class Template8 : DocumentGeneratorBase
    {
        public Template8(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory, IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) 
            : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return new Content(
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.CorrespondenceContact),
                BuildField(TemplateFieldName.Declarants),
                BuildField(TemplateFieldName.PatentAttorney),
                BuildField(TemplateFieldName.Authors),
                BuildField(TemplateFieldName.RequestNameRu),
                BuildField(TemplateFieldName.CurrentUser));
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] {"RequestId", DocumentGeneratorBase.UserInputFieldsParameterName};
        }
    }
}
