using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Db.Context
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() :base("ShopConnection") {}

        public DbSet<ProductSectionEntity> ProductSection { get; set; }

        public DbSet<ProductEntity> Product { get; set; }
    }
}
