using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Google : AppStore
    {
        public Google() : base() 
        { 

        }
        
        public Google(int numberOfApps, List<App> apps) : base(numberOfApps)
        {
            for(int i = 0; i < numberOfApps; i++)
            {
                base.Apps.Add(apps[i]);
            }
        }
        
        public Google(Google google) : base(google) 
        { 

        }

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Google AppStore!");
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

        }
        
        protected override void ReturnChange()
        {
            Console.WriteLine($"Google returns:");
            int tens = (int)(change / 10);
            Console.WriteLine($"{tens} $10 bill(s)");
            change %= 10;
            int fives = (int)(change / 5);
            Console.WriteLine($"{fives} $5 bill(s)");
            change %= 5;
            int ones = (int)change;
            Console.WriteLine($"{ones} $1 bill(s)");
        }
    }
}