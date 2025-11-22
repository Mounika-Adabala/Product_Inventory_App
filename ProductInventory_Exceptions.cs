using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_App
{
    public class ProductInventory_Exceptions : ApplicationException
    {
        public ProductInventory_Exceptions() : base()
        {
        }
        public ProductInventory_Exceptions(string message) : base(message)
        {
        }
        public ProductInventory_Exceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
