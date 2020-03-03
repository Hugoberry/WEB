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
    [DocumentGenerator(35, "POL5")]
    //[DocumentGenerator(35, DicDocumentTypeCodes.OUT_UV_Pol_vost_del_v1_19)]
    public class Template441 : DocumentGeneratorBase
    {
        public Template441(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor,
            templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return  new Content(
                BuildImage(TemplateFieldName.Image),
                BuildField(TemplateFieldName.CorrespondenceContact),
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.CurrentYear),
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.Declarants),
                BuildField(TemplateFieldName.Mktu511),                
                BuildField(TemplateFieldName.CurrentUser)
                );
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] { "RequestId" };
        }
    }
}
