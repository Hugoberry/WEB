﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace NIIS.DBConverter.Entities.References
{
    [Table("CL_TM_ICFEM")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CLTMICFEM
    {
        [Column("U_ID")]
        public int Id { get; set; }

        [Column("F_ID")]
        public int? ParentId { get; set; }

        [Column("CODE")]
        public string Code { get; set; }

        [Column("NAME_ML_EN")]
        public string NameEn { get; set; }

        [Column("NAME_ML_RU")]
        public string NameRu { get; set; }

        [Column("NAME_ML_KZ")]
        public string NameKz { get; set; }

        [Column("FULL_DESC")]
        public string Description { get; set; }
    }
}
