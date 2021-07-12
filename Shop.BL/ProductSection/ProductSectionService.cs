using Shop.Db.Context;
using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL.ProductSection
{
    public class ProductSectionService
    {
        public ProductSectionEntity GetById(int id)
        {
            ProductSectionEntity entity = new ProductSectionEntity();
            using (var context = new ShopContext())
            {
                entity = context.ProductSection.FirstOrDefault(x => x.ID == id);
            }
            return entity;
        }

        public List<ProductSectionEntity> GetList()
        {
            List<ProductSectionEntity> list = new List<ProductSectionEntity>();

            using (var context = new ShopContext())
            {
                var query = context.ProductSection;

                var result = query.ToList();
                list = result;
            }
            return list;
        }

        public ProductSectionViewModal Mapper(ProductSectionEntity entity)
        {
            ProductSectionViewModal model = new ProductSectionViewModal();

            model.Name = entity.Name;
            model.ID = entity.ID;
            model.IsActive = entity.IsActive;
            model.ParentId = entity.ParentId;
            model.DateCreate = entity.DateCreate;

            return model;
        }

        public ProductSectionEntity Edit(ProductSectionViewModal model)
        {
            ProductSectionEntity entity = new ProductSectionEntity();
            using (var context = new ShopContext())
            {
                if (model.ID == 0) context.ProductSection.Add(entity);
                else entity = context.ProductSection.FirstOrDefault(x => x.ID == model.ID);

                entity.Name = model.Name;

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
                    var entity = context.ProductSection.FirstOrDefault(x => x.ID == id);

                    if (entity != null)
                    {
                        context.ProductSection.Remove(entity);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
