using Shop.Db.Context;
using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL.Brand
{
    public class BrandService
    {
        public BrandEntity GetById(int id)
        {
            BrandEntity entity = new BrandEntity();
            using (var context = new ShopContext())
            {
                entity = context.Brand.FirstOrDefault(x => x.ID == id);
            }
            return entity;
        }
        public List<BrandEntity> GetList()
        {
            List<BrandEntity> list = new List<BrandEntity>();

            using (var context = new ShopContext())
            {
                var query = context.Brand;

                var result = query.ToList();
                list = result;
            }
            return list;
        }

        public BrandViewModal Mapper(BrandEntity entity)
        {
            BrandViewModal model = new BrandViewModal();

            model.Name = entity.Name;
            model.ID = entity.ID;
            model.IsActive = entity.IsActive;
            model.DateCreate = entity.DateCreate;

            return model;
        }

        public BrandEntity Edit(BrandViewModal model)
        {
            BrandEntity entity = new BrandEntity();
            using (var context = new ShopContext())
            {
                if (model.ID == 0) context.Brand.Add(entity);
                else entity = context.Brand.FirstOrDefault(x => x.ID == model.ID);

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
                    var entity = context.Brand.FirstOrDefault(x => x.ID == id);

                    if (entity != null)
                    {
                        context.Brand.Remove(entity);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
