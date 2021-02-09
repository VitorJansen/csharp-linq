using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    class Employees
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Wage { get; set; }

        public Employees(string name, string email, double wage)
        {
            Name = name;
            Email = email;
            Wage = wage;
        }
    }
}
