﻿
using PSSDotNetCore.RestApiWithNLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSDotNetCore.RestApiWithNLayer.Db
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }


        public DbSet<BlogModel> Blogs { get; set; }
    }
}
