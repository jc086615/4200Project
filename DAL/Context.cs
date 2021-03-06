﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _4200Project.Models;
using System.Data.Entity;

namespace _4200Project.DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, _4200Project.Migrations.MISContext.Configuration>("DefaultConnection"));
        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<_4200Project.Models.Recognition> Recognitions { get; set; }

         
    }
}