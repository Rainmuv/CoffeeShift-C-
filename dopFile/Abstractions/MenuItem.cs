namespace Abstractions
{
    
    abstract class MenuItem : IPriceable, IPrintable
    {
        public string Name {get; set;} = "";
        public decimal BasePrice {get; set;}
        public string Category {get; set;} = "";
        public int Popularity {get; set;}
        public string Tags {get; set;} = "";

        public decimal GetPrice()
        {
            return BasePrice;
        }
        public string GetPriceDescription()
        {
            return Name;
        }
        public void PrintShort()
        {
            Console.WriteLine();
        }
        public void PrintDetailed()
        {
            Console.WriteLine();
        }
    }
}