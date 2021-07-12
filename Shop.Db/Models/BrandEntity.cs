using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Db.Models
{   
    [Table("Brand")]
    public class BrandEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
