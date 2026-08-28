using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace ConsoleApp12
{
    internal class Program
    {
        public static List<Product> SearshProducts(List<Product> products, Func<Product, bool> filter)
        {

            List<Product> Result = new List<Product>();
            foreach (Product product in products)
            {
                if (filter(product))
                {
                    Result.Add(product);
                }

            }
            return Result;
        }
        public static void Printreport(List<Product> products, Action<Product> print)
        {
            foreach (Product product in products) print(product);
        }
        public static List<string> TransformProduct(List<Product> products, Func<Product, string> transform) {
            List<string> Result = new List<string>();
            foreach (Product product in products) Result.Add( transform(product));
            return Result;
        }
        static void Main(string[] args)
        {
            List<Product> Catalog = new()

            {new Product{Id=1,Name="Labtop",Price=1200,Category="Electronics",Stock=10},new Product{Id=2,Name="Phone",Price=800,Category="Electronics",Stock=25},
            new Product{Id=3,Name="T-Shirt",Price=30,Category="Clothing",Stock=100},new Product{Id=4,Name="Jeans",Price=60,Category="Clothing",Stock=50},
            new Product{Id=5,Name="Chocolate",Price=5,Category="Food",Stock=200},new Product{Id=6,Name="Coffe Beans",Price=15,Category="Food",Stock=80}
            };

            #region task1
            List<Product> Electronics = SearshProducts(Catalog, product => product.Category == "Electronics");

            List<Product> l1 = SearshProducts(Catalog, product => product.Price < 50);
            List<Product> l2 = SearshProducts(Catalog, product => product.Stock < 0);
            List<Product> l3 = SearshProducts(Catalog, product => product.Category == "Clothing" & product.Price < 100);
            Console.WriteLine("--------------------Electronics---------------------------");
            foreach (Product product in Electronics) Console.WriteLine(product);
            Console.WriteLine("--------------------Under50---------------------------");
            foreach (Product product in l1) Console.WriteLine(product);
            Console.WriteLine("--------------------in stock---------------------------");
            foreach (Product product in l2) Console.WriteLine(product);
            Console.WriteLine("--------------------Clothing under 50---------------------------");
            foreach (Product product in l3) Console.WriteLine(product);
            #endregion
            #region task3.1
            Console.WriteLine("--------------------Short report---------------------------");
            Printreport(Catalog, product => Console.WriteLine($"{product.Name}-{product.Price}$"));
            Console.WriteLine("--------------------detaild report---------------------------");
            Printreport(Catalog, product => Console.WriteLine($"[{product.Category}]{product.Name}-|price ${product.Price}| Stock{product.Stock}"));

            #endregion
            #region task3.2
            List<string> SummaryList = TransformProduct(Catalog, product => $"{product.Name}-{product.Price}$");
            Console.WriteLine("--------------------SummaryList---------------------------");
            foreach(string s in SummaryList) Console.WriteLine(s);

            List<string> Pricelable = TransformProduct(Catalog, product => product.Price>100 ? $"  {product.Name}-Expensive" : $"{product.Name}-Affordable");
            Console.WriteLine("---------------------Pricelable--------------------------");
            foreach (string s in Pricelable) Console.WriteLine(s);
            #endregion
        }

    }
}