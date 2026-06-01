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
                    Console.Clear();
           
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
                        
                        a.PrintAll();
                        break;
                    case "2": 

                        a.PrintAllavailable();
  
                        break;
                    case "3": 

                        a.PrintAll();

                        break;
                    case "4": 

                        a.PrintAll();

                        break;
                    case "5": 

                        a.PrintAll();

                        break;
                    case "6": 

                        a.PrintAll();

                        break;
                    case "7": 

                        a.PrintAll();

                        break;
                    case "8": 

                        a.PrintAll();

                        break;
                    case "9": 

                        a.PrintAll();

                        break;
                    case "10": status = false; break;
                }

                if(status) // чтобы не ждать при выходе
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}