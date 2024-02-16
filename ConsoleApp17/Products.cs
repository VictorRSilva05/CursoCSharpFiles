using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total {  get; set; }

        public Products() { }

        public Products(string name, double price, int quantity, double total)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Total = total;
        }

         public static double Subtotal(double price, int quantity)
        {
            return  price * quantity;
        }

        public override string ToString()
        {
            return Name 
                + ", "
                + Total.ToString("F2");
        }
    }
}
