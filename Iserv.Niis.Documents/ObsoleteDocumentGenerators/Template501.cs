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
    [DocumentGenerator(3311, "UV-2IP(O)")]
    public class Template501 : DocumentGeneratorBase
    {
        public Template501(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory,
          IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor,
            templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return new Content(
               BuildField(TemplateFieldName.NumberApxWork),
               BuildField(TemplateFieldName.RequestDate),
               BuildField(TemplateFieldName.RequestNumber),
               BuildField(TemplateFieldName.PatentOwner),
               BuildField(TemplateFieldName.Declarants),
               BuildField(TemplateFieldName.CorrespondenceAddress),
               BuildField(TemplateFieldName.CorrespondenceContact),
               BuildField(TemplateFieldName.RequestNameRu),
               BuildField(TemplateFieldName.RequestNameKz),
               BuildField(TemplateFieldName.CurrentUser),
               BuildField(TemplateFieldName.CurrentUserPhoneNumber)
                );
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] { "RequestId" };
        }
    }
}
