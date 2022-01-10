using Microsoft.EntityFrameworkCore;
using ServiceA.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Entities.Context
{
    public class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"data source =.; initial catalog = MsLogExampleDB; Trusted_Connection = Yes;");
        }
        public DbSet<EXCEPTION_LOG> ExceptionLog { get; set; }
    }
}
