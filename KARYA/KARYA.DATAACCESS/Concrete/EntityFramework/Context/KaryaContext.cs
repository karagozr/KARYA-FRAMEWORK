using KARYA.DATAACCESS.Helpers;
using KARYA.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KARYA.DATAACCESS.Concrete.EntityFramework.Context
{
    public class KaryaContext : DbContext
    {
        public string _connectionString;
        public KaryaContext()
        {
            _connectionString = DbConnectionHelper.GetConnectionString("KARYAConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        public DbSet<Users> Users { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }


    }
}
