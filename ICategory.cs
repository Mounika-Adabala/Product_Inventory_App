using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_App
{
    public interface ICategory
    {
        List<Category> GetAllcategories();
    }
}
