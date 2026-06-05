using Abstractions;

namespace Services
{
    class Order {
        public static int NumberOrder {get; set;}
        public string Name {get; set;}= "";
        public List<MenuItem> List = new List<MenuItem> {};
        public string Status {get; set;} = "";
        public decimal FullPrice {get; set;}
        public decimal FullDiscount {get; set;}
        public decimal ResultPrice {get; set;}
        public Order(string Name)
        {
            NumberOrder++;
            this.Name = Name;
        }
        public void DeletedOrAdd(CafeMenu cafeMenu)
        {   
            Console.WriteLine("Добавить или удалить заказ? \n 1.Добавить \n 2.Удалить");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    bool statusAdd = true;
                    cafeMenu.PrintAllavailable();
                    Console.WriteLine("Что бы добавить выберете номер продукта, для отмены выеберете 0");
                    while (statusAdd)
                    {
                        var choiceTwo = Console.ReadLine();
                        if(int.TryParse(choiceTwo, out int num))
                        {
                            if(num <= cafeMenu.ListMenu.Count && num != 0)
                            {
                                List.Add(cafeMenu.ListMenu[num - 1]);
                                Console.WriteLine("Добавлено! если хотите закончить введите 0");
                            }else 
                            {
                                statusAdd = false;
                            }
                        } else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    ;
                    break;
                case "2": 
                    bool status = true;
                    int numOrder = 1;
                    if(List.Count != 0)
                    {   
                        foreach (var item in List)
                        {
                            Console.WriteLine($"{numOrder++}. {item.Name}");
                        }
                        Console.WriteLine("Выберете номер заказа для удаления, для отмены выеберете 0");
                        while (status)
                        {
                            var choiceTwo = Console.ReadLine();
                            if(int.TryParse(choiceTwo, out int num))
                            {
                                if(num <= List.Count && num != 0)
                                {
                                    List.Remove(List[num - 1]);
                                    Console.WriteLine("Удалено! если хотите закончить введите 0");
                                }else 
                                {
                                    status = false;
                                }
                            } else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                    }
                    ;
                    break;
            }
            return ;
        }
        public void InfoAboutAllOrder()
        {
            foreach (var item in List)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}