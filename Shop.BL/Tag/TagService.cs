using Shop.BL.Brand;
using Shop.Db.Context;
using Shop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BL.Tag
{
    public class TagService
    {
        public TagEntity GetById(int id)
        {
            TagEntity entity = new TagEntity();
            using (var context = new ShopContext())
            {
                entity = context.Tag.FirstOrDefault(x => x.ID == id);
            }
            return entity;
        }
        public List<TagEntity> GetList()
        {
            List<TagEntity> list = new List<TagEntity>();

            using (var context = new ShopContext())
            {
                var query = context.Tag;

                var result = query.ToList();
                list = result;
            }
            return list;
        }

        public TagViewModal Mapper(TagEntity entity)
        {
            TagViewModal model = new TagViewModal();

            model.Name = entity.Name;
            model.ID = entity.ID;
            model.IsActive = entity.IsActive;
            model.DateCreate = entity.DateCreate;

            return model;
        }

        public TagEntity Edit(TagViewModal model)
        {
            TagEntity entity = new TagEntity();
            using (var context = new ShopContext())
            {
                if (model.ID == 0) context.Tag.Add(entity);
                else entity = context.Tag.FirstOrDefault(x => x.ID == model.ID);

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
                    var entity = context.Tag.FirstOrDefault(x => x.ID == id);

                    if (entity != null)
                    {
                        context.Tag.Remove(entity);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
