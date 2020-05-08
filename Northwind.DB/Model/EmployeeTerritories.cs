﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DB.Model
{
    class EmployeeTerritories
    {
        //Cоставной ключи EmployeeID и TerritoryID
        [Key]
        [Column(Order = 1)]
        public int EmployeeID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string TerritoryID { get; set; }
    }
}
