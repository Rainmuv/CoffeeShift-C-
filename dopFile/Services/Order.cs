using Abstractions;

namespace Services
{
    class Order {
        public static int NumberOrderStatic {get; set;}
        public int NumberOrder {get; set;}
        public string Name {get; set;}= "";
        public List<MenuItem> List = new List<MenuItem> {};
        public string Status {get; set;} = "";
        public decimal FullPrice {get; set;}
        public decimal FullDiscount {get; set;}
        public decimal ResultPrice {get; set;}
        public Order(string Name)
        {
            NumberOrderStatic++;
            NumberOrder = NumberOrderStatic;
            this.Name = Name;
        }
        public bool DeletedOrAdd(CafeMenu cafeMenu, IngredientStock stock)
        {   
            cafeMenu.PrintAllavailable(stock);
            bool whileStatus = true;
            while(whileStatus)
            {
                Console.WriteLine("1. Добавить 2. Удалить 3. Подтвердить 4. Отменить");
                var choice = Console.ReadLine();
                bool statusAdd = true;
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Что бы добавить, выберете номер, для отмены выеберете 0");
                        while (statusAdd)
                        {   
                            var choiceTwo = Console.ReadLine();
                            if(int.TryParse(choiceTwo, out int num))
                            {
                                if(num <= cafeMenu.ListMenu.Count && num != 0)
                                {   
                                    int count = 1;
                                    FullPrice += cafeMenu.ListMenu[num - 1].BasePrice;
                                    List.Add(cafeMenu.ListMenu[num - 1]);
                                    Console.WriteLine("Добавлено! выйти: 0");
                                    foreach (var item in List)
                                    {
                                        Console.WriteLine($"{count++}. {item.Name}");
                                    } 
                                    Console.WriteLine($"Сумма для оплаты: {FullPrice}");
                                }else if(num == 0)
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
                            Console.WriteLine($"Сумма для оплаты: {FullPrice}");
                            Console.WriteLine("Выберете номер заказа для удаления, для отмены выеберете 0");
                            while (status)
                            {
                                var choiceTwo = Console.ReadLine();
                                if(int.TryParse(choiceTwo, out int num))
                                {
                                    if(num <= List.Count && num != 0)
                                    {
                                        int count = 1;
                                        FullPrice -= List[num - 1].BasePrice;
                                        List.Remove(List[num - 1]);
                                        Console.WriteLine("Удалено! выйти: 0");
                                        foreach (var item in List)
                                        {
                                            Console.WriteLine($"{count++}. {item.Name}");
                                        } 
                                        Console.WriteLine($"Сумма для оплаты: {FullPrice}");
                                    }else if(num == 0)
                                    {
                                        status = false;
                                    }
                                } else
                                {
                                    Console.WriteLine("Error");
                                }
                            }
                        } else
                        {
                            Console.WriteLine("Список пуст");
                        }
                        ;
                        break;
                    case "3" : 
                        Console.WriteLine("Заказ оформлен");
                        return true;
                    ;
                    case "4" :
                        whileStatus = false
                     ; break;
                    
                }
            }
            return false;
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