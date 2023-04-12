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
        
        private Google (Google other)
        {
            Apps = other.Apps;

            Selected = other.Selected;

            Paid = other.Paid;
        }

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to Google AppStore!");
        }
        
        protected override void ReturnChange()
        {
            int change = Paid - Apps[Selected].Price;
            int [] possibleChange = {5, 2, 1};
            int [] changeGiven = new int [possibleChange.Length];
            for (int i = 0; i < possibleChange.Length; i++)
            {
                changeGiven [i] = change / possibleChange[i];
                change %= possibleChange[i];
            }
            Console.WriteLine("Giving change...\n");
            for (int i = 0; i < possibleChange.Length; i++)
            {
                Console.WriteLine($"${possibleChange[i]}: {changeGiven[i]}");
            }
        }
    }
}