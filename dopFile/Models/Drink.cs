using Abstractions;
using Services;

namespace Models
{
    class Drink : MenuItem
    {
        IngredientStock app = new IngredientStock();
        public int Volume {get; set;}
        public int Strength {get; set;}
        public bool CanBESugarFree = false;
        public Dictionary<string, int> Ingredients = new Dictionary<string, int> {};

        public Drink()
        {

        }
        public void CheckIngredients(Dictionary<string, int> _stok, Dictionary<string, int> _minStok)
        {
            
        }
    }
}

