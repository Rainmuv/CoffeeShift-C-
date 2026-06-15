using Abstractions;
using Models;

namespace Services
{
    class IngredientStock 
    {
        public Dictionary<string, int> _stock = new Dictionary<string, int>
        {
            { "кофе", 30 },
            { "молоко", 25 },
            { "вода", 50 },
            { "сахар", 40 },
            { "стакан малый", 20 },
            { "стакан большой", 15 },
            { "крышка", 30 },
            { "сироп ванильный", 10 },
            { "сироп карамельный", 10 },
            { "круассан", 8 },
            { "маффин", 6 },
            { "чизкейк", 5 },
            { "брауни", 4 }
        };  
        public Dictionary<string, int> _minStock = new Dictionary<string, int>
        {
            { "кофе", 5 },
            { "молоко", 5 },
            { "стакан малый", 5 },
            { "стакан большой", 5 },
            { "круассан", 2 },
            { "маффин", 2 },
            { "чизкейк", 2 },
            { "брауни", 2 }
        };  
        public bool HasEnough(string key, int value)
        {
            if(_stock.ContainsKey(key) && _stock[key] >= value ) return true;
            return false;
        }
        public void InfoStock()
        {
            foreach (var item in _stock)
            {   
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
        }
        public void DepossitStock()
        {   
            Console.WriteLine("Введите чего хотите добавить: \r"); 
            string? key = Console.ReadLine();
            if(key != null)
            {
                if(_stock.ContainsKey(key))
                {
                    Console.WriteLine("Сколько хотите внести? \r");
                    var count = Console.ReadLine();
                    if(int.TryParse(count, out int num))
                    _stock[key] += num;
                    Console.WriteLine($"{key} добавлено: {num} штук, текущий:{_stock[key]} \r"); 
                    return;
                } else
                {
                    Console.WriteLine("Не найдено, попробуйте еще раз \r");
                }
            }
            return;
        }
        public bool WriteOff(List<MenuItem> List, IngredientStock stock)
        {
            Dictionary<string, int> allIngredients = new Dictionary<string, int> {};
            foreach (var products in List)
            {
                if(products is Drink ax)
                {
                    if(ax.CheckIngredients(stock))
                    {
                        foreach (var item in ax.Ingredients)
                        {   
                            if (allIngredients.ContainsKey(item.Key)) {
                                allIngredients[item.Key] += item.Value; 
                            } else {
                                allIngredients[item.Key] = item.Value;  
                            }
                        }
                    }
                }else if(products is Dessert al)
                {
                    if(al.CheckIngredients(stock))
                    {
                        foreach (var item in al.Ingredients)
                        {
                            if (allIngredients.ContainsKey(item.Key)) {
                                allIngredients[item.Key] += item.Value; 
                            } else {
                                allIngredients[item.Key] = item.Value;  
                            }
                        }
                    }
                } else if(products is Combo co)
                {
                    if(co.CheckIngredients(stock))
                    {
                        foreach (var items in co.Items)
                        {
                            if(items is Drink axItem)
                            {
                                if(axItem.CheckIngredients(stock))
                                {
                                    foreach (var item in axItem.Ingredients)
                                    {
                                        if (allIngredients.ContainsKey(item.Key)) {
                                            allIngredients[item.Key] += item.Value; 
                                        } else {
                                            allIngredients[item.Key] = item.Value;  
                                        }
                                    }
                                }
                            }else if(items is Dessert alItem)
                            {
                                if(alItem.CheckIngredients(stock))
                                {
                                    foreach (var item in alItem.Ingredients)
                                    {
                                        if (allIngredients.ContainsKey(item.Key)) {
                                            allIngredients[item.Key] += item.Value; 
                                        } else {
                                            allIngredients[item.Key] = item.Value;  
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
            } 
            foreach (var item in allIngredients)
            {   
                if(HasEnough(item.Key, item.Value))
                {
                    _stock[item.Key] -= item.Value;
                    return true;
                }
            }
            return false;
        }
    }   
}