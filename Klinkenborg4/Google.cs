/********************************************************************
*** NAME : Keenan Klinkenborg   
*** CLASS : CSC 346 ***
*** ASSIGNMENT : Assignment 4
*** DUE DATE : 4/3/23
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This Program will run two forms of app stores that a user can choose from
********************************************************************/
using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    public class Google : AppStore
    {
        public Google (int selected = 0, int paid = 0) : base (selected, paid)
        {
            Selected = selected;
            Paid = paid;
            Apps = new List <App>
            {
                new App("Cubasis 3", 46, 3),
                new App("FL Studio Mobile", 50, 5),
                new App("LumaFusion Pro", 57, 1)
            };
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
            Console.WriteLine("Giving change...");
            for (int i = 0; i < possibleChange.Length; i++)
            {
                Console.WriteLine($"${possibleChange[i]}: {changeGiven[i]}");
            }
        }
    }
}