using Shop.Db.Models;
using System.Collections.Generic;

namespace Shop.BL.Product
{
    public class ProductViewModal : ProductEntity
    {
        public ProductViewModal()
        {
            ListSections = new List<ProductSectionEntity>();
        }

        public List<ProductSectionEntity> ListSections { get; set; }
    }
}
