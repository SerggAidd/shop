using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Db.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateCreate = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
