using Models;

namespace Services
{
    class CafeApplication
    {   
        public CafeMenu Cafemenu;
        public IngredientStock stock;
        public List<Customer> Customers = new List<Customer> {};
        public List<Customer> newCustomers = new List<Customer> {};
        public List<Order> activeOrder = new List<Order> {};
        public decimal allMoney = 0;
        public ShiftReport report;
        public CafeApplication(CafeMenu Cafemenu, IngredientStock stock, List<Customer> customers, ShiftReport report)
        {
            this.Cafemenu = Cafemenu;
            this.stock = stock;
            this.report = report;
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
                        Cafemenu.PrintAllavailable(stock);
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
                                    if(or.DeletedOrAdd(Cafemenu, stock))
                                    {
                                        activeOrder.Add(or);
                                        statusClient = false;
                                        statusCreateOrder = false;
                                    } else
                                    {
                                        Console.WriteLine("Создание заказа было отмененно");
                                        statusClient = false;
                                        statusCreateOrder = false;
                                    }
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
                                        statusCreateOrder = false;
                                    ;
                                    break;
                                    default: Console.WriteLine("Error"); statusCreateOrder = false;; break;
                                }   
                            }
                        }
                        break;
                    case "4": 
                        bool statusInfo = true;
                        bool CheckClient = true;
                        while (statusInfo)
                        {
                            Console.WriteLine("Введите имя клиента");
                            var choiceClientInfo = Console.ReadLine();
                            foreach (var item in Customers)
                            {
                                if(item.Name == choiceClientInfo)
                                {   
                                    item.GetInfoCustomer();
                                    statusInfo = false;
                                    CheckClient = false;
                                }
                            }
                            if(CheckClient)
                            {
                                Console.WriteLine("Не найдено");
                                statusInfo = false;
                                CheckClient = false;
                            }
                        }
                        ;
                        break;
                    case "5": 
                        stock.InfoStock();
                        break;
                    case "6": 
                        stock.DepossitStock();
                        break;
                    case "7": 
                        if(activeOrder.Count != 0)
                        {
                            foreach (var item in activeOrder)
                            {
                                Console.WriteLine($"{item.NumberOrder}, {item.Name}");
                            }
                        } else
                        {
                            Console.WriteLine("Активный ордеров нету");
                        }
                        break;
                    case "8": 
                        bool statusCompleteOrRejectOrder = true;
                        while(statusCompleteOrRejectOrder)
                        {
                            int count = 1;
                            Console.WriteLine("Введите номер для Подтверждения/Отмены, Выйти: 0");
                            if(activeOrder.Count != 0)
                            {   
                                foreach (var item in activeOrder)
                                {
                                    Console.WriteLine($"{count++}: {item.Name}");
                                }
                                var choiceWhichCompleteOrReject = Console.ReadLine();
                                if(int.TryParse(choiceWhichCompleteOrReject, out int num))
                                {
                                    if(num <= activeOrder.Count)
                                    {   
                                        Console.WriteLine("Выберете \n 1.Оплата \n 2.Отмена \n 0.Выйти");
                                        var choiceCompleteOrReject = Console.ReadLine();
                                        switch (choiceCompleteOrReject)
                                        {
                                            case "1": 
                                                foreach (var item in Customers)
                                                {    
                                                    if (activeOrder.Count != 0)
                                                    {
                                                        if(item.Name == activeOrder[num - 1].Name)
                                                        {   
                                                            if(!stock.WriteOff(activeOrder[num - 1].List, stock))
                                                            {
                                                                statusCompleteOrRejectOrder = false;
                                                                Console.WriteLine("Не хватает ингредиентов на складе");
                                                                break;
                                                            }
                                                            Console.WriteLine(activeOrder[num - 1].Name);
                                                            allMoney += activeOrder[num - 1].FullPrice;
                                                            item.GetCountOrder(activeOrder[num - 1]);
                                                            report.CompleteOrders.Add(activeOrder[num - 1]);
                                                            activeOrder.RemoveAt(num - 1);
                                                            statusCompleteOrRejectOrder = false;
                                                            Console.WriteLine("Ордер оплачен");
                                                        }
                                                    } else
                                                    {
                                                        statusCompleteOrRejectOrder = false;
                                                    }
                                                    
                                                }
                                                ; break;
                                            case "2": 
                                                report.RejectOrders.Add(activeOrder[num - 1]);
                                                activeOrder.RemoveAt(num - 1);
                                                statusCompleteOrRejectOrder = false;
                                                Console.WriteLine("Ордер отменен");
                                                ; break;
                                            case "0": 
                                            statusCompleteOrRejectOrder = false;
                                            ; break;
                                            default: Console.WriteLine(""); break;
                                        }
                                    }
                                }
                            } else
                            {   
                                statusCompleteOrRejectOrder = false;
                                Console.WriteLine("Активный ордеров нету");
                            } 
                        }
                        break;
                    case "9": 
                        report.MinReport(newCustomers, allMoney);
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