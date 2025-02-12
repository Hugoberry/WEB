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
	[DocumentGenerator(2434, "UV_PO8")]
	public class Template471 : DocumentGeneratorBase
	{
		public Template471(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory, IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
		{
            QrCodePosition = QrCodePosition.Header;
        }

		protected override Content PrepareValue()
		{
			return new Content(
				BuildField(TemplateFieldName.CorrespondenceContact),
				BuildField(TemplateFieldName.CorrespondenceAddress),
				BuildField(TemplateFieldName.RequestNumber),
				BuildField(TemplateFieldName.RequestDate),
				BuildField(TemplateFieldName.Mkpo51),
				BuildField(TemplateFieldName.RequestNameRu),
				BuildField(TemplateFieldName.Declarants),
				BuildField(TemplateFieldName.Authors),
				BuildField(TemplateFieldName.Priority31WithoutCode),
				BuildField(TemplateFieldName.Priority32WithoutCode),
				BuildField(TemplateFieldName.CurrentUser)
			);
		}

		protected override IEnumerable<string> RequiredParameters()
		{
			return new[] { "RequestId" };
		}
	}
}