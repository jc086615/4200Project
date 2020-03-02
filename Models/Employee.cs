using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4200Project.Models
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string businiessUnit { get; set; }
        public DateTime hireDate { get; set; }
        public string title { get; set; }
    }
}