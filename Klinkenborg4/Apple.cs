using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        public Apple() : base() { }
        public Apple(List<App> apps) : base(apps) { }
        public Apple(Apple apple) : base(apple) { }

        public override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Apple AppStore!");
        }
        public override void SelectApp()
        {
            Console.WriteLine("Available apps:");
            foreach (var app in Apps)
            {
                Console.WriteLine($"- {app.Name} (${app.Price}) [{app.Available} in stock]");
            }
        }
        public override void PayForApp(decimal price)
        {
            Console.WriteLine($"Apple accepts $10, $5, $1");

            decimal amountPaid = 0;
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
        public override void ReturnChange(decimal change)
        {
            Console.WriteLine($"Apple returns:");
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
           
