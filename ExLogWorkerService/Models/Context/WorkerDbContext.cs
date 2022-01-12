using ExlogWorkerService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExlogWorkerService.Models.Context
{
    public class WorkerDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"data source =.; initial catalog = WorkerLogDB; Trusted_Connection = Yes;");
        }
        public DbSet<EXCEPTION_LOG> ExceptionLog { get; set; }
    }
}
