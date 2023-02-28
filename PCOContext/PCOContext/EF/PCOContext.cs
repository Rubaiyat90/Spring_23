using PCOContext.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCOContext.EF
{
    public class PCOContext:DbContext
    {
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get;set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    
    }
}