using Iserv.Niis.DataAccess.EntityFramework.Abstract;
using Iserv.Niis.Domain.Entities.Dictionaries.DicMain;
using Microsoft.EntityFrameworkCore;

namespace Iserv.Niis.DataAccess.EntityFramework.Mappings.Dictionaries.DicMain
{
    public class DicCustomerRoleMap : IMapBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DicCustomerRole>()
                .ToTable("DicCustomerRoles");
        }
    }
}