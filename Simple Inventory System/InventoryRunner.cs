namespace Simple_Inventory_System;

public class InventoryRunner
{
    public static void RunInventory()
    {
        var inventory = new Inventory();
        

        Console.WriteLine("Welcome to this inventory management system\r");
        Console.WriteLine("-------------------------------------------\n");

        while (true)
        {
            Console.WriteLine("please select your choice");
            try
            {
                var choice = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("please select a valid choice");
                continue;
            }
        }
        
    }
}