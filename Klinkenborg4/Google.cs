using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Google : AppStore
    {
        public Google (List <App>? app = null, int selected = 0, int paid = 0) : base (app, selected, paid)
        {
            Apps = app ?? new List <App>();

            Selected = selected;
            
            Paid = paid;
        }
        
        private Google (Google old)
        {
            Apps = old.Apps;

            Selected = old.Selected;

            Paid = old.Paid;
        }

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Google AppStore!");
        }
        
        protected override void ReturnChange()
        {
            decmial change = 0.0;
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