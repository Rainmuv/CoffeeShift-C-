using Models;

namespace Services
{
    class CafeApplication
    {   
        public CafeMenu Cafemenu;
        public IngredientStock stock;
        public List<Customer> Customers = new List<Customer> {};
        public CafeApplication(CafeMenu Cafemenu, IngredientStock stock, List<Customer> customers)
        {
            this.Cafemenu = Cafemenu;
            this.stock = stock;
            foreach (var item in customers)
            {
                this.Customers.Add(item);
            }
        }
        public void Run()
        {   
            bool status = true;
            while(status)
            {   
                Console.WriteLine(
                    "1. Показать меню кофейни\n" +
                    "2. Показать только доступные позиции\n" +
                    "3. Создать новый заказ\n" +
                    "4. Найти клиента\n" +
                    "5. Показать склад\n" +
                    "6. Пополнить склад\n" +
                    "7. Показать активные заказы\n" +
                    "8. Завершить или отменить заказ\n" +
                    "9. Показать отчёт смены\n" +
                    "10. Выход"
                );  

                var choice = Console.ReadLine();
                switch(choice)
                {
                    case "1": 
                        Cafemenu.PrintAll();
                        break;
                    case "2": 
                        Cafemenu.PrintAllavailable();
                        break;
                    case "3": 
                        bool statusCreateOrder = true;
                        while(statusCreateOrder)
                        {
                            Console.WriteLine("Введите имя клиента");
                            var choiceClient = Console.ReadLine();
                            bool statusClient = true;
                            foreach (var item in Customers)
                            {
                                if(item.Name == choiceClient)
                                {   
                                    var or = new Order(item.Name);
                                    or.DeletedOrAdd(Cafemenu);
                                    item.GetCountOrder(or);
                                    statusClient = false;
                                    statusCreateOrder = false;
                                    break;
                                }
                            }
                            if(statusClient)
                            {
                                Console.WriteLine("Клиент не найден, хотите создать? \n 1. Да \n 2. Нет");
                                var choiceYesOrNo = Console.ReadLine();
                                switch (choiceYesOrNo)
                                {
                                    case "1": 
                                    Console.WriteLine("Введите имя");
                                    var inputNameClient = Console.ReadLine();
                                    Console.WriteLine("Есть ли бонусы?");
                                    var inputBonusClient = Console.ReadLine();
                                    Console.WriteLine("Лояльность клиента? \n 1.New \n 2.Regular \n 3.Vip");
                                    var inputLoyalteClient = Console.ReadLine();
                                    switch(inputLoyalteClient)
                                        {
                                            case "1": inputLoyalteClient = "New"; break;
                                            case "2": inputLoyalteClient = "Regular"; break;
                                            case "3": inputLoyalteClient = "Vip"; break;
                                            default: inputLoyalteClient = "New"; break;
                                        }
                                    if(inputNameClient != null && int.TryParse(inputBonusClient, out int Bonus) && inputLoyalteClient != null)
                                        {   
                                            
                                            Customers.Add(new Customer(inputNameClient, inputLoyalteClient, Bonus));
                                        }
                                    ;
                                    break;
                                    case "2": 
                                        
                                    ;
                                    break;
                                    default: Console.WriteLine("Error"); break;
                                }   
                            }
                        }
                        
                        break;
                    case "4": 
                        Cafemenu.PrintAll();
                        break;
                    case "5": 
                        stock.InfoStock();
                        break;
                    case "6": 
                        stock.DepossitStock();
                        break;
                    case "7": 

                        break;
                    case "8": 
                        Cafemenu.PrintAll();
                        break;
                    case "9": 
                        Cafemenu.PrintAll();
                        break;
                    case "10": status = false; break;
                    default: Console.WriteLine("Error"); break;
                }

                if(status)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}