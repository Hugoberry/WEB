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
    [DocumentGenerator(139, "PREKRPM")]
    public class Template449 : DocumentGeneratorBase
    {
        public Template449(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper)
            : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return new Content(
                BuildField(TemplateFieldName.CorrespondenceContact),
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.GosNumber),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.PatentOwner),
                BuildField(TemplateFieldName.DateEarlyTermination),
                BuildField(TemplateFieldName.BulletinNumber),
                BuildField(TemplateFieldName.BulletinDate),
                BuildField(TemplateFieldName.CurrentUserPhoneNumber),
                BuildField(TemplateFieldName.CurrentUser));
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] {"RequestId"};
        }
    }
}