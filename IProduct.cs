using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_App
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product p);
        //Product ModifyProduct(string productcode);
        //Product DeleteProduct(string productcode);
        //List<Product> GetProductsByName(string productname);

    }
}
