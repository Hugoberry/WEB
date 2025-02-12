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
	[DocumentGenerator(3692, "001.001_1PM")]
	public class Template200 : DocumentGeneratorBase
	{
		public Template200(IExecutor executor, ITemplateFieldValueFactory templateFieldValueFactory, IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper) : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
		{
            QrCodePosition = QrCodePosition.Header;
        }

		protected override Content PrepareValue()
		{
			return new Content(
				BuildField(TemplateFieldName.TransferDateWithCode),
				BuildField(TemplateFieldName.Declarants),
				BuildField(TemplateFieldName.ApplicantAddress),
				BuildField(TemplateFieldName.Priority31),
				BuildField(TemplateFieldName.Priority32),
				BuildField(TemplateFieldName.Priority33),
				BuildField(TemplateFieldName.RequestNameRu),
				BuildField(TemplateFieldName.CorrespondenceContact),
				BuildField(TemplateFieldName.CorrespondenceAddress),
				BuildField(TemplateFieldName.CorrespondencePhone),
				BuildField(TemplateFieldName.CorrespondencePhoneFax),
				BuildField(TemplateFieldName.CorrespondenceEmail),
				BuildField(TemplateFieldName.PatentAttorney),
				BuildField(TemplateFieldName.AuthorAddress),
				BuildField(TemplateFieldName.Authors)
			);
		}

		protected override IEnumerable<string> RequiredParameters()
		{
			return new[] { "RequestId" };
		}
	}
}