using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Db.Models
{
    [Table("Product")]
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }

        public int SectionId { get; set; }      
        [ForeignKey("SectionId")]
        public ProductSectionEntity Section {get; set;}
    }
}
