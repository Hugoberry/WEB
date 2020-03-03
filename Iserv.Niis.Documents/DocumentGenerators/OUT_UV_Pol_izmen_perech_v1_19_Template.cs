﻿using Iserv.Niis.Common.Codes;
using Iserv.Niis.Documents.Abstractions;
using Iserv.Niis.Documents.Attributes;
using Iserv.Niis.Documents.Enums;
using Iserv.Niis.Documents.UserInput.Abstract;
using Iserv.Niis.FileConverter.Abstract;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace Iserv.Niis.Documents.DocumentGenerators
{
    [DocumentGenerator(0, DicDocumentTypeCodes.UV_TZ_VN_IZM_PERECH_TOV)]
    public class OUT_UV_Pol_izmen_perech_v1_19_Template : DocumentGeneratorBase
    {
        public OUT_UV_Pol_izmen_perech_v1_19_Template(IExecutor executor,
            ITemplateFieldValueFactory templateFieldValueFactory,
            IFileConverter fileConverter, IDocxTemplateHelper docxTemplateHelper)
            : base(executor, templateFieldValueFactory, fileConverter, docxTemplateHelper)
        {
            QrCodePosition = QrCodePosition.Header;
        }
        protected override Content PrepareValue()
        {
            return new Content(
                BuildField(TemplateFieldName.CorrespondenceAddress),
                BuildField(TemplateFieldName.RequestNumber),
                BuildField(TemplateFieldName.RequestDate),
                BuildField(TemplateFieldName.Declarants),
                BuildField(TemplateFieldName.Priority300),
                BuildField(TemplateFieldName.HeadName),
                BuildField(TemplateFieldName.DeclarantsNew),
                BuildField(TemplateFieldName.DicDetailICGS),
                BuildField(TemplateFieldName.CurrentUser),
                BuildField(TemplateFieldName.CurrentUserPhoneNumber),
                BuildField(TemplateFieldName.Icgs511));
        }

        protected override IEnumerable<string> RequiredParameters()
        {
            return new[] { "RequestId" };
        }
    }
}
