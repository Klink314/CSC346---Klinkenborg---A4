namespace AppStoreNS
{
    public class App
    {
        public string Name { get; set; }
        public int Price { get; set; }
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
