using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DB.Model
{
    //Регионы
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        [MaxLength(50)]
        public int RegionDescription { get; set; }
    }
}
