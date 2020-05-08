using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DB.Model
{
    class Territories
    {
        [Key]
        public string TerritoryID { get; set; }
        [MaxLength(50)]
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}
