﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DB_Sale
{
    public class MSSQLContext:DbContext
    {
        public MSSQLContext() : base(GetOptions())
        {
        }

        private static DbContextOptions GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<MSSQLContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Bikes> Bikes { get; set; }
        public DbSet<Rents> Rents { get; set; }



    }
}
