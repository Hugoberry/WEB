﻿using Iserv.Niis.DataAccess.EntityFramework.Abstract;
using Iserv.Niis.Domain.Entities.Document;
using Microsoft.EntityFrameworkCore;

namespace Iserv.Niis.DataAccess.EntityFramework.Mappings.Document
{
    public class DocumentExecutorMap : IMapBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentExecutor>()
                .ToTable("DocumentExecutors");
        }
    }
}