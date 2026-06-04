using Models;

namespace Services
{
    class CafeApplication
    {   
        CafeMenu Cafemenu;
        IngredientStock stock;
        public CafeApplication(CafeMenu Cafemenu, IngredientStock stock)
        {
            this.Cafemenu = Cafemenu;
            this.stock = stock;
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
                        Cafemenu.PrintAll();
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
                        Cafemenu.PrintAll();
                        break;
                    case "8": 
                        Cafemenu.PrintAll();
                        break;
                    case "9": 
                        Cafemenu.PrintAll();
                        break;
                    case "10": status = false; break;
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