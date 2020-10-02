using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        
        public string Code { get; set; }
        [Column(TypeName ="int")]
        public int Qty { get; set; }
        [Column(TypeName = "bit")]
        public bool Active { get; set; }
    }
}
