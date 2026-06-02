using Abstractions;
using Services;

namespace Models
{
    class Drink : MenuItem
    {
        public int Volume {get; set;}
        public int Strength {get; set;}
        public bool CanBESugarFree = false;
        public Dictionary<string, int> Ingredients = new Dictionary<string, int>{};
        public bool CheckIngredients(IngredientStock app)
        {
            foreach (var item in Ingredients)
            {
                if(!app.HasEnough(item.Key, item.Value)) return false;
            }
            return true;
        }
    }
}

