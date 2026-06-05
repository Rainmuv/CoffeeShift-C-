using Abstractions;
using Services;

namespace Models
{
    class Dessert : MenuItem
    {
        public int Weight {get; set;}
        public string Sweetness {get; set;} = "";
        public int Freshness {
            get => field; 
            set {
                field = value;
                switch (value)
                {
                    case 2: BasePrice -= 15; break;
                    case 1: BasePrice -= 25; break;
                }
            }
            }
        public Dictionary<string, int> Ingredients = new Dictionary<string, int>{};
        public bool CheckIngredients(IngredientStock app)
        {   
            if(Freshness == 0) return false;
            foreach (var item in Ingredients)
            {
                if(!app.HasEnough(item.Key, item.Value)) return false;
            }
            return true;
        }
    }
}