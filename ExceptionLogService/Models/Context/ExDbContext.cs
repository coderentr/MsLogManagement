using ExceptionLogService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLogService.Models.Context
{
    public class ExDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"data source =.; initial catalog = GlobalLogDB; Trusted_Connection = Yes;");
        }
        public DbSet<EXCEPTION_LOG> ExceptionLog { get; set; }
    }
}
