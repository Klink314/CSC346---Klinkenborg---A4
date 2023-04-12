/********************************************************************
*** NAME : Keenan Klinkenborg   
*** CLASS : CSC 346 ***
*** ASSIGNMENT : Assignment 4
*** DUE DATE : 4/3/23
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This Program will run two forms of app stores that a user can choose from
********************************************************************/
namespace AppStoreNS
{
    class Program
    {
        static void Main (string [] args)
        {
            int userChoice;
            bool finished = false;
            Apple appleStore = new Apple ();
            Google googleStore = new Google ();
            do
            {
                Console.WriteLine("Please make a selection.");
                Console.WriteLine("1. Apple Appstore");
                Console.WriteLine("2. Google Appstore");
                Console.WriteLine("3. Exit");
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1: 
                            appleStore.PurchaseApp();
                            break;
                        case 2:
                            googleStore.PurchaseApp();
                            break;
                        case 3:
                            Console.WriteLine("Thank you for using the Appstores!");
                            finished = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please enter a correct response.");
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid character, please enter a correct option.");
                }
                if (userChoice == 3)
                {
                    return;
                }
            } while (!finished);
        }
    }
}