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
	[DocumentGenerator(2793, "MTZ4")]
	public class Template79 : DocumentGeneratorBase
	{
		public Template79(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory, 
			IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor, 
				templateFieldValueFactory, fileConverter, docxTemplateHelper)
		{
            QrCodePosition = QrCodePosition.Header;
        }

		protected override Content PrepareValue()
		{
			return new Content(
				BuildField(TemplateFieldName.PatentGosNumber),
				BuildField(TemplateFieldName.RequestDate),
				BuildImage(TemplateFieldName.Image),
				BuildField(TemplateFieldName.PatentOwner),
				BuildField(TemplateFieldName.PatentOwnerAddress),
				BuildField(TemplateFieldName.Icgs511),
				BuildField(TemplateFieldName.CurrentUser),
				BuildField(TemplateFieldName.Disclaimer),
				BuildField(TemplateFieldName.CurrentDate)
			);
		}

		protected override IEnumerable<string> RequiredParameters()
		{
			return new[] { "RequestId", DocumentGeneratorBase.UserInputFieldsParameterName };
		}
	}
}