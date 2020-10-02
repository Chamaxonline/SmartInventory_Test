using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string UserName { get; set; }
        public byte[] HashPassword { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
    }
}
