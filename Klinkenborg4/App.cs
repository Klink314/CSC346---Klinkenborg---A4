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
    public class App
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Available { get; set; }

        public App(string name = "", int price = 0, int available = 0)
        {
            Name = name;
            Price = price;
            Available = available;
        }

        public App(App other)
        {
            Name = other.Name;
            Price = other.Price;
            Available = other.Available;
        }
    }
}
