using System.Globalization;
using System.IO;
namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\prote\source\repos\products.csv.txt";
            Console.Write("Please insert file path: ");
            string path = Console.ReadLine();

            List<Products> products = new List<Products>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        string productName = values[0];
                        double productPrice = double.Parse(values[1], CultureInfo.InvariantCulture);
                        int productQuantity = int.Parse(values[2], CultureInfo.InvariantCulture);
                        products.Add(new Products(productName, productPrice, productQuantity, Products.Subtotal(productPrice,productQuantity)));
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocurred.");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
