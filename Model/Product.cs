using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column("nvarchar(250)")]
        public string Description { get; set; }
        [Column("nvarchar(10)")]
        public string Code { get; set; }
        [Column("bit")]
        public bool Active { get; set; }
    }
}
