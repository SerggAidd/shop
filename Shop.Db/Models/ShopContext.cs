using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Db.Context
{
    public class ShopContext : System.Data.Entity.DbContext
    {
        public ShopContext() :base("ShopConnection") {}

        public DbSet<ProductSectionEntity> ProductSection { get; set; }

        public DbSet<ProductEntity> Product { get; set; }

        public DbSet<BrandEntity> Brand { get; set; }
        public DbSet<TagEntity> Tag { get; set; }
    }
}
