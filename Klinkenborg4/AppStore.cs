using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public abstract class AppStore
    {
        protected List<App> Apps { get; set; } = new List<App>();
        protected int Selected { get; set; }
        protected int Paid { get; set; }

        public AppStore(int selected = 0, int paid = 0)
        {
            Apps = new List <App>();
            Selected = selected;
            Paid = paid;
        }

        private AppStore(AppStore other)
        {
            Apps = other.Apps;
            Selected = other.Selected;
            Paid = other.Paid;
        }
        
        public void PurchaseApp()
        {
            Selected = 0;
            int userChoice;
            bool finished = false;
            do
            {
                WelcomeToStore();
                SelectApp();
                PayForApp();
                ReturnChange();
                DownloadApp();
                Console.WriteLine("Would you like to leave the store?");
                Console.WriteLine("1. Continue");
                Console.WriteLine("2. Exit Store");
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1: 
                        Console.WriteLine("Welcome Back!");
                        break;
                        default:
                        finished = true;
                        Console.WriteLine("Thank you for using the app store!");
                        break;
                    }
                }
            }while(!finished);
        }
        
        protected abstract void WelcomeToStore();
        
        protected virtual void SelectApp()
        {
            Console.WriteLine("Select an app from the list below:");
            int index = 1;
            foreach (App app in Apps)
            {
                Console.WriteLine($"{index}. {app.Name} (${app.Price}) [{app.Available} available]");
                index++;
            }
            Console.Write("Enter the number of the app you want to purchase: ");
            int choice = int.Parse(Console.ReadLine()) - 1;
            while (choice < 0 || choice >= Apps.Count || Apps[choice].Available == 0)
            {
                Console.WriteLine("Invalid choice. Please select another app.");
                choice = int.Parse(Console.ReadLine()) - 1;
            }
            Selected = choice;
        }
        
        protected virtual void PayForApp() 
        { 
            int payment = 0; 
            int[] bills = {20, 10};
            int numberBills = 0;
            bool accepted = false;
            Console.WriteLine ("The Google Appstore accepts $20 and $10 bills.");
            do
            {
                payment = 0;
                for (int i = 0; i < bills.Length; i++)
                {
                    do
                    {
                        Console.Write($"Enter the amount of ${bills[i]} bills: ");
                        accepted = int.TryParse(Console.ReadLine(), out numberBills);
                    } while (!accepted);
                    payment += bills[i] * numberBills;
                }
                if (payment < Apps[Selected].Price)
                {
                    Console.WriteLine("Insufficient funds. Please try entering the correct amount again.");
                    Console.WriteLine("Make sure to enter enough to cover the cost of the app.");
                }
            } while(payment < Apps[Selected].Price);
            Apps[Selected].Available--;
            Paid = payment;
        }
        
        protected virtual void ReturnChange() 
        {
            int change = Paid - Apps[Selected].Price;
            int [] possibleChange = {10, 1};
            int [] changeGiven = new int [possibleChange.Length];
            for (int i = 0; i < possibleChange.Length; i++)
            {
                changeGiven [i] = change / possibleChange[i];
                change %= possibleChange[i];
            }
            Console.WriteLine("Giving change...");
            for (int i = 0; i < possibleChange.Length; i++)
            {
                Console.WriteLine($"{possibleChange[i]}: {changeGiven[i]}");
            }
        }

        protected virtual void DownloadApp()
        {
            Console.WriteLine("Proper payment has been made, thank you!");
            Console.WriteLine("Downloading your selected app...");
            Console.WriteLine("Download complete.");
        }
    }
}

