using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        public Apple (int selected = 0, int paid = 0) : base (selected, paid)
        {
            Selected = selected;
            Paid = paid;
            Apps = new List<App>
            {
                new App("Final Cut Pro", 54, 3),
                new App("Logic Pro", 50, 4),
                new App("MainStage", 46, 5),
                new App("Pixelmator Pro", 57, 2)
            };
            
        }
        
        private Apple (Apple other)
        {
            Apps = other.Apps;
            Selected = other.Selected;
            Paid = other.Paid;
        }

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Apple AppStore!");
        }
        
        protected override void PayForApp()
        {
            int payment = 0; 
            int[] bills = {10, 5, 1};
            int numberBills = 0;
            bool accepted = false;
            Console.WriteLine ("The Apple Appstore accepts $10, $5 and $1 bills.");
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
    }
}

           
