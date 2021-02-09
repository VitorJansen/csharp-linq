using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            

            List<Employees> list = new List<Employees>();

            using (StreamReader reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] content = reader.ReadLine().Split(',');
                    string name = content[0];
                    string email = content[1];
                    double wage = double.Parse(content[2], CultureInfo.InvariantCulture);

                    Employees emp = new Employees(name, email, wage);
                    list.Add(emp);
                }
            }
                        
            var emails = list.Where(x => x.Wage > salary).Select(x => x.Email);
            Console.WriteLine($"Email of people whose salary is greater than: {salary.ToString("F2", CultureInfo.InvariantCulture)}");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }

            var sum = list.Where(x => x.Name[0] == 'M').Select(x => x.Wage).Sum();
            Console.WriteLine("Sum of salary of employees whose name starts whith 'M'" 
                + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
