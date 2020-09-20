using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Sales_Commision_MVC.Models;

namespace Product_Sales_Commision_MVC.Data
{
    public class Product_Sales_Commision_MVCContext : DbContext
    {
        public Product_Sales_Commision_MVCContext (DbContextOptions<Product_Sales_Commision_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Product_Sales_Commision_MVC.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<Product_Sales_Commision_MVC.Models.Product> Product { get; set; }

        public DbSet<Product_Sales_Commision_MVC.Models.Sale> Sale { get; set; }

        public DbSet<Product_Sales_Commision_MVC.Models.SalesAgent> SalesAgent { get; set; }
    }
}
