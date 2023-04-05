using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        public Apple(int numberOfApps) : base(numberOfApps) 
        { 
            numberOfApps = 4;
            Apps.Add(new App("Final Cut Pro", 54, 3));
            Apps.Add(new App("Logic Pro", 50, 4));
            Apps.Add(new App("MainStage", 46, 5));
            Apps.Add(new App("Pixelmator Pro", 57, 2));
        }
        
        public Apple(int numberOfApps, List<App> apps) : base(numberOfApps) 
        { 
            for(int i = 0; i < numberOfApps; i++)
            {
                base.Apps.Add(apps[i]);
            }
        }

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Apple AppStore!");
        }
        
        protected override void PayForApp()
        {
            Console.WriteLine("AppleStore accepts $10, $5, $1");
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
    }
}

           
