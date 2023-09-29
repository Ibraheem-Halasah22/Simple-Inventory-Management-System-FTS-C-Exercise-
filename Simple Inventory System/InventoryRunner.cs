namespace Simple_Inventory_System;

public enum InventoryRunningChoice
{
    AddProduct = 1,
    ViewAllItems = 2,

    ExitTheProgram = 6,
}

public class InventoryRunner
{
    public static void PrintChoicesList()
    {
        Console.WriteLine("Choices are as the following:");
        Console.WriteLine("1. Add Product.");
        Console.WriteLine("2. View all products.");

        Console.WriteLine("6. Exit.");
    }
    
    public static void PrintProduct(Product product)
    {
        Console.WriteLine($"Product with ID {product.Id}");
        Console.WriteLine($"Product's name is {product.Name}");
        Console.WriteLine($"Product's price is {product.Price}");
        Console.WriteLine($"Product's quantity is {product.Quantity}");

        Console.WriteLine("---------------------------------------");
    }

    public static void RunInventory()
    {
        var inventory = new Inventory();


        Console.WriteLine("Welcome to this inventory management system\r");
        Console.WriteLine("-------------------------------------------\n");

        while (true)
        {
            PrintChoicesList();
            int choice;
            Console.WriteLine("please select your choice");
            try
            {
                choice = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Error.WriteLine("please select a valid choice");
                continue;
            }

            switch (choice)
            {
                case ((int)InventoryRunningChoice.AddProduct):
                    Console.WriteLine("Please enter the product's name:");
                    var newProductName = Console.ReadLine();

                    Console.WriteLine("Please enter the product's price:");
                    float newProductPrice = 0;
                    while (true)
                    {
                        try
                        {
                            newProductPrice = (float)Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Please enter a valid price value");
                        }

                        if (newProductPrice > 0) break;
                        Console.Error.WriteLine("Please enter a positive price value");
                    }

                    Console.WriteLine("Please enter the product's quantity:");
                    int newProductQty = 0;
                    while (true)
                    {
                        try
                        {
                            newProductQty = Convert.ToInt16(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.Error.WriteLine("Please enter a valid quantity value");
                        }

                        if (newProductQty >= 0) break;
                        Console.Error.WriteLine("Please enter a non negative price value");
                    }

                    inventory.AddProduct(name: newProductName, quantity: newProductQty, price: newProductPrice);
                    Console.WriteLine("Product added successfully!");
                    break;

                case (int)InventoryRunningChoice.ViewAllItems:
                    var productsList = inventory.GetAllProducts();
                    if (productsList.Count == 0) Console.WriteLine("You have no products in the inventory");

                    foreach (var product in productsList)
                    {
                        PrintProduct(product);
                    }

                    break;
                
                case (int)InventoryRunningChoice.ExitTheProgram :
                    Environment.Exit(0);
                    break;
                
            }
        }
    }
}