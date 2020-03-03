﻿using Iserv.Niis.DataAccess.EntityFramework.Abstract;
using Iserv.Niis.Domain.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;

namespace Iserv.Niis.DataAccess.EntityFramework.Mappings.Dictionaries
{
    public class DicPositionMap : IMapBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DicPosition>()
                .ToTable("DicPositions");
        }
    }
}