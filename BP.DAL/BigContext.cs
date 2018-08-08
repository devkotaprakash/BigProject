using BigProject.BP.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace BP.DAL
{
   public  class BigContext : DbContext
    {

        public BigContext(DbContextOptions<BigContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
