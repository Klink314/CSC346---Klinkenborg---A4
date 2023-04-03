using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        public Apple() : base() 
        { 

        }
        
        public Apple(int numberOfApps, List<App> apps) : base(numberOfApps) 
        { 
            for(int i = 0; i < numberOfApps; i++)
            {
                base.Apps.Add(apps[i]);
            }
        }
        
        public Apple(Apple apple) : base(apple) 
        { 

        }

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Apple AppStore!");
        }

        protected override void SelectApp()
        {
            Console.WriteLine("Available apps:");
            foreach (var app in Apps)
            {
                Console.WriteLine($"- {app.Name} (${app.Price}) [{app.Available} in stock]");
            }
        }
        
        protected override void PayForApp()
        {
            Console.WriteLine($"Apple accepts $10, $5, $1");

            int amountPaid = 0;
            decimal change = 0;
            Console.Write($"Enter the quantity of $10 bills: ");
            int tens = int.Parse(Console.ReadLine());
            amountPaid += tens * 10;
            Console.Write($"Enter the quantity of $5 bills: ");
            int fives = int.Parse(Console.ReadLine());
            amountPaid += fives * 5;
            Console.Write($"Enter the quantity of $1 bills: ");
            int ones = int.Parse(Console.ReadLine());
            amountPaid += ones;
            change = amountPaid - price;

            if (change >= 0)
            {
                ReturnChange(change);
            }
            else
            {
                Console.WriteLine($"Insufficient funds. Please pay ${price}.");
                PayForApp(price);
            }
        }
        
        protected override void ReturnChange()
        {

        }
    }
}
           
