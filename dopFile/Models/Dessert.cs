using Abstractions;

namespace Models
{
    class Dessert : MenuItem
    {
        public int Weight {get; set;}
        public string Sweetness {get; set;} = "";
        public int Freshness {get; set;}
        public Dictionary<string, int> Ingredients = new Dictionary<string, int>{};
        public void GetPriceDescription(Dictionary<string, int> _stok, Dictionary<string, int> _minStok)
        {
            foreach (var item in Ingredients)
            {
                if(_stok.ContainsKey(item.Key) && _stok[item.Key] > _minStok[item.Key])
                {
                    Console.WriteLine(123);
                }
            }
        }
    }
}