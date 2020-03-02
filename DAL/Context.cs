using System;
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

        }

        public DbSet<Employee> Employees { get; set; }
    }
}