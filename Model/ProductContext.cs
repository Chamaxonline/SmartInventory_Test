using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
    }
}
