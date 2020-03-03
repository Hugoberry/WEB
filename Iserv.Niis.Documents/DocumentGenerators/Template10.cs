﻿using System.Collections.Generic;
using Iserv.Niis.Common.Codes;
using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.Documents.UserInput.Abstract;
using Iserv.Niis.FileConverter.Abstract;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;
using TemplateEngine.Docx;

namespace Iserv.Niis.Documents.DocumentGenerators
{
    /// <summary>
    /// Шаблон документа "30_Запрос экспертизы заявки на выдачу патента на изобретение (Форма ИЗ-2б)"
    /// </summary>
    [DocumentGenerator(115, DicDocumentTypeCodes.RequestForExaminationOfInventionPatentRequest)]
    public class Template10 : DocumentGeneratorBase
    {
        public Template10(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor,
            templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }

        protected override Content PrepareValue()
        {
            return new Content(
                    BuildField(TemplateFieldName.CorrespondenceAddress),
                    BuildField(TemplateFieldName.CorrespondenceContact),
                    BuildField(TemplateFieldName.RequestNumber),
                    BuildField(TemplateFieldName.RequestDate),
                    BuildField(TemplateFieldName.RequestNameRu),
                    BuildField(TemplateFieldName.CustomerPhone),
                    BuildField(TemplateFieldName.CustomerEmail),
                    BuildField(TemplateFieldName.CurrentUser),
                    BuildField(TemplateFieldName.HeadName)
            );
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] {"RequestId", DocumentGeneratorBase.UserInputFieldsParameterName};
        }
    }
}