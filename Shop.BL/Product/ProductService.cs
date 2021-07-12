using Shop.Db.Context;
using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Shop.BL.Product
{
    public class ProductService
    {
        public ProductEntity GetById(int id)
        {
            ProductEntity entity = new ProductEntity();
            using (var context = new ShopContext())
            {
                entity = context.Product.FirstOrDefault(x => x.ID == id);
            }
            return entity;
        }
        public List<ProductEntity> GetList()
        {
            List<ProductEntity> list = new List<ProductEntity>();

            using (var context = new ShopContext())
            {
                var query = context.Product;

                var result = query
                    .Include(x => x.Section)
                    .ToList();
                list = result;
            }
            return list;
        }

        public ProductViewModal Mapper(ProductEntity entity)
        {
            ProductViewModal model = new ProductViewModal();

            model.Name = entity.Name;
            model.ID = entity.ID;
            model.IsActive = entity.IsActive;
            model.SectionId = entity.SectionId;
            model.DateCreate = entity.DateCreate;

            return model;
        }

        public ProductEntity Edit(ProductViewModal model)
        {
            ProductEntity entity = new ProductEntity();
            using (var context = new ShopContext())
            {
                if (model.ID == 0) context.Product.Add(entity);
                else entity = context.Product.FirstOrDefault(x => x.ID == model.ID);

                entity.Name = model.Name;
                entity.SectionId = model.SectionId;


                context.SaveChanges();
            }
            return entity;
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                using (var context = new ShopContext())
                {
                    var entity = context.Product.FirstOrDefault(x => x.ID == id);

                    if (entity != null)
                    {
                        context.Product.Remove(entity);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
