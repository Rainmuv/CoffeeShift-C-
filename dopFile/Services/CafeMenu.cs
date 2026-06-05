using Abstractions;
using Models;

namespace Services
{
    class CafeMenu : MenuItem
    {   
        public CafeMenu(List<MenuItem> allProducts)
        {
            foreach (var item in allProducts)
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
            int count = 1;
            Console.WriteLine($"Доступно сейчас: \r");
            foreach (var item in ListMenu)
            {
                if(item is Drink ax)
                {
                    if(ax.CheckIngredients(new IngredientStock()))
                    {
                        Console.WriteLine($"{count++}. {item.Name}");
                    }
                }else if(item is Dessert al)
                {
                    if(al.CheckIngredients(new IngredientStock()))
                    {
                        Console.WriteLine($"{count++}. {item.Name}");
                    }
                } else if(item is Combo co)
                {
                    if(co.CheckIngredients(new IngredientStock()))
                    {
                        Console.WriteLine($"{count++}. {item.Name}");
                    }
                }
            }
        }
    }
}