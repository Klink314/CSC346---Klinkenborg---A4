using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public abstract class AppStore
    {
        protected List<App> Apps { get; set; } = new List<App>();
        protected int Selected;
        protected int Paid;

        public AppStore(int numberOfApps = 0)
        {
            Apps = new List<App>(numberOfApps);
        }

        private AppStore(AppStore other)
        {
            Selected = other.Selected;
            Paid = other.Paid;
            Apps = new List<App>(other.Apps);
        }
        
        public void PurchaseApp()
        {

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
            Console.WriteLine("Please enter the quantity of each payment value:");
            Console.Write("$20 bills: ");
            int twenty = int.Parse(Console.ReadLine());
            Console.Write("$10 bills: ");
            int ten = int.Parse(Console.ReadLine());
            int totalPaid = twenty * 20 + ten * 10;
            while (totalPaid < 0 || totalPaid < Apps.Last().Price)
            {
                Console.WriteLine("Insufficient payment. Please enter more money.");
                Console.Write("$20 bills: ");
                twenty = int.Parse(Console.ReadLine());
                Console.Write("$10 bills: ");
                ten = int.Parse(Console.ReadLine());
                totalPaid = twenty * 20 + ten * 10;
            }
            int changeDue = totalPaid - Apps.Last().Price;
            Console.WriteLine($"Change due: ${changeDue}");
            Apps[Selected].Available--;
        }
        
        protected virtual void ReturnChange() 
        {
            Console.WriteLine("AppStore returns $10, $1");
        }

        protected virtual void DownloadApp()
        {
            Console.WriteLine("Downloading {app.Name}...");
        }
    }
}

