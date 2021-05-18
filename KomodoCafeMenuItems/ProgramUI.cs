using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenuItems
{
    public class ProgramUI
    {
        CafeMenuRepository _repo = new CafeMenuRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option\n" +
                    "1. Create Menu Items\n" +
                    "2. View Full Menu\n" +
                    "3. Update Existing Items\n" +
                    "4. Delete Menu Items\n" +
                    "5. Exit");

                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        CreateMenuItems();
                        break;
                    case "2":
                        ViewFullMenu();
                        break;
                    case "3":
                        UpdateExistingItems();
                        break;
                    case "4":
                        DeleteMenuItems();
                        break;
                    case "5":
                        //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose the number corresponding with what action you would like to take.");
                        break;
                }
                Console.WriteLine("Press any key to contine");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateMenuItems()
        {
            Console.Clear();
            CafeMenu newMenuItem = new CafeMenu();
            Console.WriteLine("What would you like to call this menu item?");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Please provide a description for this menu item.");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("What ingredients are used for this item?");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("What is the price for this item?");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = Convert.ToDouble(priceAsString);
            newMenuItem.Price = priceAsDouble;


            bool wasAdded = _repo.CreateMenuItems(newMenuItem);
            if (wasAdded)
            {
                Console.WriteLine("The item was added to the menu correctly");
            }
            else
            {
                Console.WriteLine("The item was not added to the menu");
            }
        }
        private void ViewFullMenu()
        {
            Console.Clear();
            List<CafeMenu> allMenuItems = _repo.ViewMenu();
            Console.WriteLine(allMenuItems);
            foreach (CafeMenu menuItem in allMenuItems)
            {
                Console.WriteLine($"Meal Name: {menuItem.MealName}\n" +
                    $"Meal Description: {menuItem.MealDescription}\n" +
                    $"Meal ingredients: {menuItem.Ingredients}\n" +
                    $"Meal Price: {menuItem.Price}");

            }
        }
        private void UpdateExistingItems()
        {
            Console.Clear();
            ViewFullMenu();
            Console.WriteLine("Please enter the name of the menu item you would like to update.");

            string itemName = Console.ReadLine();

            CafeMenu newItem = new CafeMenu();

            Console.WriteLine("What would you like to name this item?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Please provide a description of the menu item.");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("What ingredients are used to make this item?");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("What is the price for this item?");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = Convert.ToDouble(newItem);
            newItem.Price = priceAsDouble;
        }
        private void DeleteMenuItems()
        {
            Console.Clear();
            ViewFullMenu();
            Console.WriteLine("Enter the name for the menu item you would like to delete");
            bool wasDeleted = _repo.DeleteMenuItems(Console.ReadLine());
            if (wasDeleted)
            {
                Console.WriteLine("Item was successfully deleted from the menu");
            }
            else
            {
                Console.WriteLine("The item could not be deleted from the menu, please try again.");
            }
        }
    }
}
