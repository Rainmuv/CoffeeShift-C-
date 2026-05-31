using Models;

namespace Services
{
    class CafeApplication
    {   
        CafeMenu a;
        public CafeApplication(CafeMenu bob)
        {
            a = bob;
        }
        public void Run()
        {
            bool status = true;
            bool statusMenu = true;
            while(status)
            {
                if(statusMenu)
                {
                    Console.WriteLine("1. Показать меню кофейни");
                    Console.WriteLine("2. Показать только доступные позиции");
                    Console.WriteLine("3. Создать новый заказ");
                    Console.WriteLine("4. Найти клиента");
                    Console.WriteLine("5. Показать склад");
                    Console.WriteLine("6. Пополнить склад");
                    Console.WriteLine("7. Показать активные заказы");
                    Console.WriteLine("8. Завершить или отменить заказ");
                    Console.WriteLine("9. Показать отчёт смены");
                    Console.WriteLine("10. Выход");
                }
                var choice = Console.ReadLine();

                switch(choice)
                {
                    case "1": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "2": 
                        Console.Clear();
                        
                        Console.ReadKey();
                        break;
                    case "3": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "4": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "5": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "6": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "7": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "8": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "9": 
                        Console.Clear();
                        a.PrintAll();
                        Console.ReadKey();
                        break;
                    case "10": status = false; break;
                }
                Console.Clear();
            }
        }
    }
}