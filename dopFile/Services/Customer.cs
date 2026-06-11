namespace Services
{
    class Customer
    {
        public string Name {get; set;} = "";
        public Dictionary<int, Order> CountOrder = new Dictionary<int, Order> {};
        public int BonusCount {get; set;}
        public string Loyalte {get; set;} = "";
        public string FavoryteCategory {get; set;} = "";
        public Customer(string Name,  string Loyalte, int BonusCount = 0)
        {
            this.Name = Name;
            this.BonusCount = BonusCount;
            this.Loyalte = Loyalte;
        }

        public void GetCountOrder(Order order)
        {
            CountOrder.Add(order.NumberOrder, order);
        }
        public void GetBonus()
        {
            
        }
        public void HowWillDiscount()
        {
            
        }
        public void FavoryteOrder()
        {
            
        } 
        public void GetInfoCustomer()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Количество заказов: {CountOrder.Count}");
            Console.WriteLine($"Количество бонусов: {BonusCount}");
            Console.WriteLine($"Лояльность: {Loyalte}");
            Console.WriteLine($"Любимый товар: {FavoryteCategory}");
        }
        
    }
}