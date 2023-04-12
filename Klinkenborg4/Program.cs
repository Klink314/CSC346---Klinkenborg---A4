namespace AppStoreNS
{
    class Program
    {
        static void Main (string [] args)
        {
            int userChoice;
            bool finished = false;
            List <App> appleApps = new List<App>
            {
                new App("Final Cut Pro", 54, 3),
                new App("Logic Pro", 50, 4),
                new App("MainStage", 46, 5),
                new App("Pixelmator Pro", 57, 2)
            };
            Apple appleStore = new Apple (appleApps);
            List <App> googleApps = new List <App>
            {
                new App("Cubasis 3", 46, 3),
                new App("FL Studio Mobile", 50, 5),
                new App("LumaFusion Pro", 57, 1)
            };
            Google googleStore = new Google (googleApps);
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