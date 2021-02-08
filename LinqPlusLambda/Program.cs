using LinqPlusLambda.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;

namespace LinqPlusLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1};
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            //Exemplo de uso cláusula WHERE e condicionais múltiplas
            var result1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("Products where Tier = 1 and Price < 900", result1);

            //Combinação de WHERE com SELECT
            var result2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("Names of products from Tools", result2);


            //Select com objeto anonimo que tem caracteristicas especificas
            var result3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name});
            Print("Names started with C and anonymous object", result3);

            //Ordernar a lista com OrderBy e ThenBy
            var result4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("Tier 1, order by price then by name", result4);

            //Pular e pegar resultados em um range determinado (Skip e take)
            var result5 = result4.Skip(2).Take(4);
            Print("Skip the first 2 and Take the next 4", result5);

            //FirstOrDefault: Pegar o primeiro resultado ou retornar nulo
            var result6 = products.FirstOrDefault();
            Console.WriteLine("First or Default test1: " + result6);
            //exemplo FOD com resultado nulo
            var result7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or Default test1: " + result7);
            Console.WriteLine();
        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
    }
}
