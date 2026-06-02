using Abstractions;
using Models;

namespace Services
{
    class CafeMenu : MenuItem
    {   
        public CafeMenu(List<Drink> drinks, List<Dessert> desserts, List<Combo> combos)
        {
            foreach (var item in drinks)
            {
                ListMenu.Add(item);
            }
            foreach (var item in desserts)
            {
                ListMenu.Add(item);
            }
            foreach (var item in combos)
            {
                ListMenu.Add(item);
            }
        }
        

        public List<MenuItem> ListMenu = new List<MenuItem> {};
        public Dictionary<string, List<MenuItem>> DictionaryMenu = new Dictionary<string, List<MenuItem>> {};

        public void PrintAll()
        {
            foreach (var item in ListMenu)
            {
                Console.WriteLine($"{item.Name} цена:{item.BasePrice}");
            }
        }
        public void PrintAllavailable()
        {
            foreach (var item in ListMenu)
            {
                if(item is Drink ax)
                {
                    if(ax.CheckIngredients(new IngredientStock()))
                    {
                        Console.WriteLine($"Доступно сейчас:{item.Name}");
                    }
                }else if(item is Dessert al)
                {
                    if(al.CheckIngredients(new IngredientStock()))
                    {
                        Console.WriteLine($"Доступно сейчас:{item.Name}");
                    }
                } else if(item is Combo co)
                {
                    
                }
            }
        }
    }
}