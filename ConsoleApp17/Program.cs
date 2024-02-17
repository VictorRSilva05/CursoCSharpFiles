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
            try
            {
                string sourceFolderPath = Path.GetDirectoryName(path);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                string[] lines = File.ReadAllLines(path);
                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        string productName = values[0];
                        double productPrice = double.Parse(values[1], CultureInfo.InvariantCulture);
                        int productQuantity = int.Parse(values[2], CultureInfo.InvariantCulture);

                        Products products = new Products(productName, productPrice, productQuantity, Products.Subtotal(productPrice, productQuantity));

                        sw.WriteLine(products.Name + ", " + products.Total);
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
