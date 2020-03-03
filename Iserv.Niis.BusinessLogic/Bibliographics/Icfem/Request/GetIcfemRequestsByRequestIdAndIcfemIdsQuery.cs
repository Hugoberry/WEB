﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iserv.Niis.Domain.Entities.ManyToManyMappingEntities;
using Microsoft.EntityFrameworkCore;
using Iserv.Niis.DataBridge.Repositories;  using Iserv.Niis.DataBridge.Implementations; //using NetCoreCQRS; .Queries;

namespace Iserv.Niis.BusinessLogic.Bibliographics.Icfem.Request
{
    public class GetIcfemRequestsByRequestIdAndIcfemIdsQuery : BaseQuery
    {
        public async Task<List<DicIcfemRequestRelation>> ExeciuteAsync(int requestId, List<int> icfemIds)
        {
            var icfemRequestRepo = Uow.GetRepository<DicIcfemRequestRelation>();
            return await icfemRequestRepo
                .AsQueryable()
                .Where(ir => ir.RequestId == requestId && icfemIds.Contains(ir.DicIcfemId))
                .ToListAsync();
        }
    }
}