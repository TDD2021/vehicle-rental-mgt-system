using System;
using System.Collections.Generic;
using System.Linq;


namespace A1TimDonaldDavis
{
    //Class to handle output and validate user input. 
    class Menu
    {
        //fields for input, tryParse, and vehicle collection.
        private int _choice;
        private bool _validInput, _cancel;
        private Dictionary<int, Vehicle> _inventory;

        //On creation point to dictionary, set tryParse to false and call start method
        public Menu(Dictionary<int, Vehicle> vehicles)
        {
            _inventory = vehicles;
            _validInput = false;
            MainMenu();
        }

        //Print main menu and get user input
        public void MainMenu()
        {
            Console.Clear();
            Console.Write("\n\n\tAssignment_1 By Tim Donald-Davis \n\n" +
                "--------------------------------------------------------------");
            Console.Write("\n\n\n\t1 - View all vehicles \n\t2 - View available vehicles " +
                "\n\t3 - View reserved vehicles \n\t4 - Reserve a vehicle \n\t5 - cancel reservation " +
                "\n\t6 - Exit \n\nEnter your choice: ");
            getInput();
        }
        //Continue checking input until valid option entered, then clear console and switch menus or end program.
        public void getInput()
        {
            ValidateInt();
            Console.Clear();
            switch (_choice)
            {
                case 1:
                    ViewAll();
                    break;
                case 2:
                    ViewAvailable();
                    break;
                case 3:
                    ViewReserved();
                    break;
                case 4:
                    Reserve();
                    break;
                case 5:
                    Cancel();
                    break;
                case 6:
                    Console.WriteLine("\n\nExit has been Selected.. Program Now Ending...\n\n");
                    Environment.Exit(1);
                    break;
                default:
                    Console.Write("\nInvalid input. Please enter between 1-6: ");
                    getInput();
                    break;
            }
        }

        // method for checking if input is a valid integer, if not keep prompting.
        public void ValidateInt()
        {
            if (!Int32.TryParse(Console.ReadLine(), out _choice))
            {
                Console.Write("Please enter valid input: ");
                while (_validInput == false)
                {
                    _validInput = Int32.TryParse(Console.ReadLine(), out _choice) ? true : false;
                    Console.Write("Please enter valid input: ");
                }
            }
            _validInput = false;
        }

        //method for checking if input is not only valid int but valid option depending on if canceling or reserving.
        public void ValidateAvailable(bool cancel)
        {
            ValidateInt();
            if (_choice == 0)
                MainMenu(); 

            _choice -= 1;
            while ((!_inventory.ContainsKey(_choice) || _inventory[_choice].IsReserved) && !cancel)
            {
                Console.Write("Please select from vehicles shown above: ");
                ValidateAvailable(cancel);
            }

            while ((!_inventory.ContainsKey(_choice) || !_inventory[_choice].IsReserved) && cancel)
            {
                Console.Write("Please select from vehicles shown above: ");
                ValidateAvailable(cancel);
            }

        }

        //Print all vehicles w/ all fields and prompt to return to main menu 
        public void ViewAll()
        {
            var inventory = from vehicle in _inventory
                            select vehicle;

            Console.WriteLine("\n\tId Name\t\t\t\tRental Price\tAvailable\tCategory\tType");
            foreach (KeyValuePair<int, Vehicle> vehicle in _inventory)
            {
                Console.WriteLine(vehicle.Value.ToString());
            }
            ReturnMainMenu();
        }

        //print vehicles w/o isReserved field and while not reserved
        public void ViewAvailable()
        {
            var available = from vehicle in _inventory
                            where vehicle.Value.IsReserved == false
                            select vehicle;

            Console.Write($"\n\tTotal Number of unreserved Vehicles: ");
            CheckResults(available);
            ReturnMainMenu();
        }

        //method to print linq results for all fields except isreserved, if none prompt to return to main menu  
        public void CheckResults(IEnumerable<KeyValuePair<int, Vehicle>> search)
        {
            if (search.Any())
            {
                Console.Write($"{search.Count()}\n\n\tId Name\t\t\t\tRental Price\tCategory\tType\n");
                foreach (KeyValuePair<int, Vehicle> vehicle in search)
                    Console.WriteLine(vehicle.Value.Availability());
            }
            else
            {
                Console.Write($"\n\n\tNo Vehicles Found \n\n");
                ReturnMainMenu();
            }
        }

        //linq to print only reserved vehicles
        public void ViewReserved()
        {
            var reserved = from vehicle in _inventory
                           where vehicle.Value.IsReserved == true
                           select vehicle;
            Console.Write($"\n\tTotal Number of Reserved Vehicles: ");
            CheckResults(reserved);
            ReturnMainMenu();
        }

        //Print non reserved vehicles, check input and provide feedback if reserved 
        public void Reserve()
        {
            _cancel = false;
            var available = from vehicle in _inventory
                            where vehicle.Value.IsReserved == false
                            select vehicle;

            Console.Write($"\n\tTotal Number of Available Vehicles: ");
            CheckResults(available);

            Console.Write("\nEnter 0 to return to Main Menu\nEnter Vehicle ID to reserve : ");

            ValidateAvailable(_cancel);
            _inventory[_choice].IsReserved = true;
            Console.Clear();
            Console.WriteLine("\nVehicle Reservation Completed\n");
            Confirmation();
        }

        //Print reserved vehicles, check input and provide feedback on if canceled
        public void Cancel()
        {
            _cancel = true;
            var reserved = from vehicle in _inventory
                           where vehicle.Value.IsReserved == true
                           select vehicle;

            Console.Write($"\n\tTotal Number of Reserved Vehicles: ");
            CheckResults(reserved);
            Console.Write("\nEnter 0 to return to Main Menu\nEnter Vehicle ID to cancel reservation: ");
            ValidateAvailable(_cancel);

            _inventory[_choice].IsReserved = false;
            Console.Clear();
            Console.WriteLine("\nVehicle Reservation Cancelled Succesfully\n");
            Confirmation();
        }

        //print reserved / canceled vehicle
        public void Confirmation()
        {
            Console.WriteLine("\n\tId Name\t\t\t\tRental Price\tCategory\tType");
            Console.WriteLine(_inventory[_choice].Availability());
            ReturnMainMenu();
        }
        //prompt for any key and return to main menu.
        public void ReturnMainMenu()
        {
            Console.Write("\nPress any key to return to Main Menu: ");
            Console.ReadKey();
            MainMenu();
        }


    }
}
