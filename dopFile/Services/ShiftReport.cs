namespace Services
{
    class ShiftReport
    {
        public List<Order> CompleteOrders = new List<Order> {};
        public List<Order> RejectOrders = new List<Order> {};
        public Dictionary<string, List<Order>>  AllOrders = new Dictionary<string, List<Order>> {};

        public ShiftReport()
        {
            AllOrders.Add("Выполненые", CompleteOrders);
            AllOrders.Add("Отменёные", RejectOrders);
        }

        public void AllBill()
        {
            
        }
        public void StatisticSellOrCategory()
        {
            
        }
        public void CheckPopularItemAndClient()
        {
            
        }
        public void CheckStock()
        {
            
        }
        public void MinReport(List<Customer> NewCustomers, decimal allMoney)
        {
            Console.WriteLine($"Общее количество заказов: {AllOrders["Выполненые"].Count + AllOrders["Отменёные"].Count} Выполненых: {CompleteOrders.Count}");
            Console.WriteLine($"Новыъ клиентов: {NewCustomers.Count}");
            Console.WriteLine($"Общая выручка: {allMoney}");
        }
    }
}