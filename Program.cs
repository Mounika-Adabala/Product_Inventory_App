namespace Product_Inventory_App
{
    public class Program
    {
        public void ProdOperation(string adminInput, Product_Operations operation, ref bool adminMode)
        {
            Product prod = new Product();
            switch (adminInput)
            {
                case "1":
                    {
                        operation.GetAllProducts();
                        //Console.WriteLine("Product Added Succesfully!!!");
                        //operation.GetAllProducts();
                        break;
                    }

                case "2":
                    {

                        adminMode = false;
                        //showsubmenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("invalid Operation");
                        break;
                    }
            }
        }
        /*static void showsubmenu()
        {
            Program program = new Program();
            Product_Operations operation = new Product_Operations();
            bool adminMode = true;
            while (adminMode)
            {
                Console.Clear();
                Console.WriteLine("-----Product Menu-----");
                Console.WriteLine("[1] Get All Product");
                //Console.WriteLine("[2] Add Product");
                //Console.WriteLine("[3] Modify Product");
                //Console.WriteLine("[4] Udpate Product");
                //Console.WriteLine("[5] Search Product By Product Name");
                Console.WriteLine("[2] Exit Product Menu And Go to Maain Menu");
                Console.Write("\nSelect one option:");
                string adminInput = Console.ReadLine();
                program.ProdOperation(adminInput, operation, ref adminMode);
                Console.WriteLine("please [Enter] to go Back");
                Console.ReadKey();
            }
        }*/
        static void Main(string[] args)
        {
            Program program = new Program();
            Product_Operations operation = new Product_Operations();
            Category_Operations category = new Category_Operations();
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("-----PRODUCT INVENTORY MANAGEMENT-----");
                Console.WriteLine("[1]  : Categories");
                Console.WriteLine("[2]  : Products");
                Console.WriteLine("[3]  : Exit");
                Console.Write("\nSelect one option:");
                string selectedOption = Console.ReadLine();
                Console.WriteLine();
                switch (selectedOption)
                {
                    case "1":
                        //Console.WriteLine("Hello World");
                        category.GetAllcategories();
                        break;

                    case "2":
                        {
                            bool adminMode = true;
                            while (adminMode)
                            {
                                Console.Clear();
                                Console.WriteLine("-----Product Menu-----");
                                Console.WriteLine("[1] Get All Product");
                                Console.WriteLine("[2] Add Product");
                                //Console.WriteLine("[3] Modify Product");
                                //Console.WriteLine("[4] Udpate Product");
                                //Console.WriteLine("[5] Search Product By Product Name");
                                Console.WriteLine("[2] Exit Product Menu And Go to Maain Menu");
                                Console.Write("\nSelect one option:");
                                string adminInput = Console.ReadLine();
                                program.ProdOperation(adminInput, operation, ref adminMode);
                                Console.WriteLine("please [Enter] to go Back");
                                Console.ReadKey();
                            }
                            //showsubmenu();
                            break;

                        }

                    //Console.WriteLine("Hello World");
                    //category.GetAllcategories();
                    //break;
                    case "3":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("invalid Operation");
                            break;
                        }
                }
                Console.WriteLine("\nPress [Enter] For Main Menu");
                Console.ReadKey();
            }

        }
    }
}
