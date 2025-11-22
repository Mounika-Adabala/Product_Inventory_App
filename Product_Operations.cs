using ConsoleTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Product_Inventory_App
{
    public class Product_Operations : IProduct
    {

        List<Product> products = new List<Product>
        {
            new Product
            {
                ProductCode = "P001",
                ProductName = "Soaps",
                CategoryCode = "001",
                AvailableQuantity = 100,
                ProductPrice = 8000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 20,
                    MinQuantity = 2
                }
            },
            new Product
            {
                ProductCode = "P002",
                ProductName = "Milk",
                CategoryCode = "002",
                AvailableQuantity = 200,
                ProductPrice = 80000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 25,
                    MinQuantity = 10
                }
            },

            new Product
            {
                ProductCode = "P003",
                ProductName = "Pens",
                CategoryCode = "003",
                AvailableQuantity = 300,
                ProductPrice = 8000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 10,
                    MinQuantity = 5
                }
            },

            new Product
            {
                ProductCode = "P004",
                ProductName = "Shirts",
                CategoryCode = "004",
                AvailableQuantity = 30,
                ProductPrice = 62000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 20,
                    MinQuantity = 3
                }
            },

            new Product
            {
                ProductCode = "P005",
                ProductName = "Mobiles",
                CategoryCode = "005",
                AvailableQuantity = 20,
                ProductPrice = 61000,
                productOnDiscount = new ProductOnDiscount
                {
                    DiscountPercentage = 10,
                    MinQuantity = 2
                }
            },


        };

        public List<Product> GetAllProducts()
        {
            var table = new ConsoleTable("ProductCode", "ProductName", "CategoryCode", "AvailableQuantity", "ProductPrice", "DiscountPercentage", "MinQuantity");
            foreach (var product in products)
            {
                table.AddRow(product.ProductCode, product.ProductName, product.CategoryCode, product.AvailableQuantity, product.ProductPrice, product.productOnDiscount.DiscountPercentage, product.productOnDiscount.MinQuantity);
            }
            table.Write();
            var result = products.ToList();
            return result;
            //return products;
        }
        public Product AddProduct(Product p)
        {
            try
            {
                Console.WriteLine("Enter ProductCode as P001,P002,and so on...");
                p.ProductCode = Console.ReadLine();
                if (string.IsNullOrEmpty(p.ProductCode))
                    throw new ProductInventory_Exceptions("Invalid ProductCode...");
                if (!Regex.IsMatch(p.ProductCode, @"^[A-Za-z]\d{3}$")) throw new ProductInventory_Exceptions("Invalid ProductCode...");
                Console.WriteLine("Enter ProductName as string value...");
                p.ProductName = Console.ReadLine();
                if (string.IsNullOrEmpty(p.ProductName))
                    throw new ProductInventory_Exceptions("Invalid ProductName...");

                Console.WriteLine("Enter Category Code as 001,002,003 as string");
                p.CategoryCode = Console.ReadLine();
                Console.WriteLine("Enter AvailableQuantity as integer value");
                p.AvailableQuantity = Convert.ToInt32(Console.ReadLine());
                if (p.AvailableQuantity <= 0)
                {
                    throw new ProductInventory_Exceptions("AvailableQuantity should be > 0");
                }
                Console.WriteLine("Enter Product Price as double value...");
                p.ProductPrice = Convert.ToDouble(Console.ReadLine());
                if (p.ProductPrice <= 0)
                {
                    throw new ProductInventory_Exceptions("Product Price should be > 0");
                }



            }
            catch (ProductInventory_Exceptions ex)
            {
                string complete_data = $"Error:{ex.Message}\n" +
                    $"Date and Time:{DateTime.Now.ToShortDateString()}\n" +
                    $"Class and Method Line:{ex.StackTrace}\n" +
                    $"Source:{ex.Source}\n";
                FileStream fs = new FileStream(@"D:\CSharp\Practice\Product_Inventory_App\Error_Log.txt",
                    FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(complete_data);
                writer.Flush();
                writer.Close();
            }
            p.productOnDiscount.DiscountPercentage = 10;
            p.productOnDiscount.MinQuantity = 10;



            products.Add(p);
            return p;
        }
        //public Product ModifyProduct(string productcode)
        //{
        //    Product result = new Product();
        //    result.ProductCode = productcode;
        //    //Product result1 = new Product();
        //    try
        //    {
        //        //Console.WriteLine("Enter a product code as string like P001,P002");
        //        //productcode = Console.ReadLine();
        //        if (result.ProductCode == null)
        //        {
        //            throw new Inventory_CustomException("Product code does not exists");  // custom exception


        //        }
        //        else
        //        {
        //            result = products.Find(x => x.ProductCode == productcode);
        //            //Console.WriteLine("Udpate ProductCode as string like P001,P002 and so..on");
        //            //result.ProductCode = Console.ReadLine();
        //            result.ProductCode = productcode;
        //            Console.WriteLine("Update ProductName as string");
        //            result.ProductName = Console.ReadLine();
        //            Console.WriteLine("Update CategoryCode as integer like 001,002 and so..on");
        //            result.CategoryCode = Convert.ToInt32(Console.ReadLine());
        //            Console.WriteLine("Udpate AvailableQuantity as integer value and should be > 0 value");
        //            result.AvailableQuantity = Convert.ToInt32(Console.ReadLine());
        //            if (result.AvailableQuantity < 0)
        //            {
        //                throw new Inventory_CustomException("Product Qty should be > 0");
        //            }
        //            Console.WriteLine("Enter Product Price as double value and should be > 0 value");
        //            result.ProductPrice = Convert.ToDouble(Console.ReadLine());
        //            if (result.ProductPrice < 0)
        //            {
        //                throw new Inventory_CustomException("Product Price should be > 0");
        //            }

        //        }
        //        //GetAllProducts();



        //    }
        //    catch (Inventory_CustomException ex)
        //    {
        //        string complete_data = $"Error:{ex.Message}\n" +
        //            $"Date and Time:{DateTime.Now.ToShortDateString()}\n" +
        //            $"Class and Method Line:{ex.StackTrace}\n" +
        //            $"Source:{ex.Source}\n";
        //        FileStream fs = new FileStream(@"C:\Users\RPBVVN\source\repos\CSHARP_PRODUCT_INVENTORY\Error_Log.txt",
        //            FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //        StreamWriter writer = new StreamWriter(fs);
        //        writer.Write(complete_data);
        //        writer.Flush();
        //        writer.Close();
        //    }
        //    //productlist.Add(result);
        //    return result;

        //}

        //public Product DeleteProduct(string productcode)
        //{
        //    //p1 = new Program();
        //    Product result = new Product();

        //    try
        //    {
        //        Console.WriteLine("Enter a product code as string like P001,P002");
        //        productcode = Console.ReadLine();
        //        if (productcode == null)
        //        {
        //            throw new Inventory_CustomException("Product code does not exists");  // custom exception


        //        }
        //        else
        //        {
        //            //var deleteproduct=productlist.RemoveAll(s=>s.ProductCode == productcode);
        //            result = products.Find(x => x.ProductCode == productcode);
        //            products.Remove(result);
        //            //productlist.RemoveAll(s => s.ProductCode == productcode);
        //            Console.WriteLine("Product Deleted Successfully....");
        //            //return result;
        //            //GetAllProducts();

        //        }

        //    }
        //    catch (Inventory_CustomException ex)
        //    {
        //        string complete_data = $"Error:{ex.Message}\n" +
        //            $"Date and Time:{DateTime.Now.ToShortDateString()}\n" +
        //            $"Class and Method Line:{ex.StackTrace}\n" +
        //            $"Source:{ex.Source}\n";
        //        FileStream fs = new FileStream(@"C:\Users\RPBVVN\source\repos\CSHARP_PRODUCT_INVENTORY\Error_Log.txt",
        //            FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //        StreamWriter writer = new StreamWriter(fs);
        //        writer.Write(complete_data);
        //        writer.Flush();
        //        writer.Close();
        //    }
        //    return result;

        //}
        //public List<Product> GetProductsByName(string productname)
        //{
        //    var result = products.Where(x => x.ProductName == productname).ToList();
        //    var table = new ConsoleTable("ProductCode", "ProductName", "CategoryCode",
        //       "AvailableQuantity", "ProductPrice");
        //    foreach (var dispresult in result)
        //    {
        //        table.AddRow(dispresult.ProductCode, dispresult.ProductName, dispresult.CategoryCode,
        //            dispresult.AvailableQuantity, dispresult.ProductPrice);
        //    }
        //    table.Write();
        //    return result.ToList();

        //}
        //public Product AddProductOnDiscount(Product p)
        //{
        //    ProductOnDiscount productOnDiscount = new ProductOnDiscount();
        //    Console.WriteLine("Enter ProductCode as P001,P002,and so on...");
        //    p.ProductCode = Console.ReadLine();
        //    if (string.IsNullOrEmpty(p.ProductCode))
        //        throw new Inventory_CustomException("Invalid ProductCode...");
        //    if (!Regex.IsMatch(p.ProductCode, @"^[A-Za-z]\d{3}$")) throw new Inventory_CustomException("Invalid ProductCode...");
        //    Console.WriteLine("Enter ProductName as string value...");
        //    p.ProductName = Console.ReadLine();
        //    if (string.IsNullOrEmpty(p.ProductName))
        //        throw new Inventory_CustomException("Invalid ProductName...");

        //    Console.WriteLine("Enter Category Code as 001,002,003 and so on...");
        //    p.CategoryCode = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Enter AvailableQuantity as integer value");
        //    p.AvailableQuantity = Convert.ToInt32(Console.ReadLine());
        //    if (p.AvailableQuantity <= 0)
        //    {
        //        throw new Inventory_CustomException("AvailableQuantity should be > 0");
        //    }
        //    Console.WriteLine("Enter Product Price as double value...");
        //    p.ProductPrice = Convert.ToDouble(Console.ReadLine());
        //    if (p.ProductPrice <= 0)
        //    {
        //        throw new Inventory_CustomException("Product Price should be > 0");
        //    }
        //    Console.WriteLine("Enter Discount Percentage");
        //    productOnDiscount.DiscountPercentage = Convert.ToDouble(Console.ReadLine());
        //    Console.WriteLine("Enter Minimum Qty Pick");
        //    productOnDiscount.MinQuantity = Convert.ToInt32(Console.ReadLine());


        //    products.Add(new Product
        //    {
        //        ProductCode = p.ProductCode,
        //        ProductName = p.ProductName,
        //        CategoryCode = p.CategoryCode,
        //        AvailableQuantity = p.AvailableQuantity,
        //        ProductPrice = p.ProductPrice,
        //        productOnDiscount = new ProductOnDiscount
        //        {
        //            DiscountPercentage =
        //        productOnDiscount.DiscountPercentage,
        //            MinQuantity = productOnDiscount.MinQuantity
        //        }
        //    });
        //    return p;
        //}
        //public List<Product> GetAllDiscountProducts()
        //{
        //    var table = new ConsoleTable("ProductCode", "ProductName", "CategoryCode",
        //      "AvailableQuantity", "ProductPrice", "DiscountPercentage", "MinimumQtyPick");
        //    foreach (var dispresult in products)
        //    {
        //        table.AddRow(dispresult.ProductCode, dispresult.ProductName,
        //            dispresult.CategoryCode,
        //            dispresult.AvailableQuantity, dispresult.ProductPrice,
        //            dispresult.productOnDiscount.DiscountPercentage,
        //            dispresult.productOnDiscount.MinQuantity);
        //    }
        //    table.Write();
        //    var result = products.ToList();
        //    return result;
        //}



    }
}
        
    
