using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Db.Models
{
    [Table("ProductSection")]
    public class ProductSectionEntity : BaseEntity
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public ProductSectionEntity Parent { get; set; }
    }
}
