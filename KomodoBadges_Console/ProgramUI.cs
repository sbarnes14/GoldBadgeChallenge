using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public class ProgramUI
    {
        BadgesRepository _repo = new BadgesRepository();

        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select a menu option\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                
                switch (input.ToLower())
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose the number for the action you would like to take");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void AddABadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();

            Console.WriteLine("Please enter a badge number");
            string badgeIDAsString = Console.ReadLine();
            int badgeIDAsInt = Convert.ToInt32(badgeIDAsString);
            newBadge.BadgeID = badgeIDAsInt;
            
            Console.WriteLine("What doors does this badge need access to?\n" +
                "1. A1\n" +
                "2. A2\n" +
                "3. A3\n" +
                "4. A4\n" +
                "5. A5\n" +
                "6. A6\n" +
                "7. A7\n" +
                "8. A8\n" +
                "9. A9");
            newBadge.TypeOfDoor = new List<DoorType>; Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Does this badge need access to any other doors? (y/n)");
            if (Console.ReadKey().KeyChar == 'y')
            {
                Console.Clear();
                Console.WriteLine("What doors does this badge need access to?\n" +
                "1. A1\n" +
                "2. A2\n" +
                "3. A3\n" +
                "4. A4\n" +
                "5. A5\n" +
                "6. A6\n" +
                "7. A7\n" +
                "8. A8\n" +
                "9. A9");
                newBadge.TypeOfDoor = new List<DoorType>; Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.Clear();
            }
            bool wasAdded = _repo.AddBadge(newBadge);
            if (wasAdded)
            {
                Console.WriteLine("The Badge was entered successfully");
            }
            else
            {
                Console.WriteLine("The badge was not entered correctly, please try again");
            }
        }
        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you would like to edit?");
            Console.ReadLine();
            List<Badges> allBadges = _repo.ViewAllBadges();
            foreach (Badges badgeId in allBadges)
            {
                Console.WriteLine($" {badgeId.BadgeID} has access to door(s) {badgeId.TypeOfDoor} && {badgeId.TypeOfDoor}");
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add a door\n" +
                    "2. Remove a door");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        AddADoor();
                        break;
                    case "2":
                        RemoveADoor();
                        break;
                    default:
                        Console.WriteLine("Please choose one of the options above");
                        break;
                }
            }
        }
        private void AddADoor()
        {

        }
        private void RemoveADoor()
        {

        }
        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine($" {"BadgeID",-10} {"Door Access",-10}");
            List<Badges> allBadges = _repo.ViewAllBadges();
            foreach(Badges content in allBadges)
            {
                Console.WriteLine($" {content.BadgeID,-10} {content.TypeOfDoor} && {content.TypeOfDoor}"); 
            }
        }
    }
}
