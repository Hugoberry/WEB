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
	[DocumentGenerator(1711, "PRIL_TZ_IZM")]
	public class Template310 : DocumentGeneratorBase
	{
		public Template310(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory, IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
		{
            QrCodePosition = QrCodePosition.Header;
        }

		protected override Content PrepareValue()
		{
			return new Content(
				BuildField(TemplateFieldName.DocumentNumber),
				BuildField(TemplateFieldName.PatentGosNumber),
				BuildField(TemplateFieldName.GosReestrChangeDateInWordsRu),
				BuildField(TemplateFieldName.GosReestrChangeDateInWordsKz),
				BuildField(TemplateFieldName.GosReestrChangeYearInWordsKz),
				BuildField(TemplateFieldName.PatentOwner),
				BuildField(TemplateFieldName.PatentOwnerAddress),
				BuildField(TemplateFieldName.PresidentKz),
				BuildField(TemplateFieldName.President)
			);
		}

		protected override IEnumerable<string> RequiredParameters()
		{
			return new[] { "RequestId" };
		}
	}
}