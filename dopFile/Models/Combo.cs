using Abstractions;

namespace Models
{
    class Combo : MenuItem
    {   
        public int Discount;
        public List<MenuItem> Items = new List<MenuItem> {};
        public Combo(Drink drink, Dessert dessert, int Discount)
        {
            this.Discount = Discount;
            Items.Add(drink);
            Items.Add(dessert);
            foreach (var item in Items)
            {

                BasePrice += item.BasePrice;
            }
            BasePrice -= BasePrice * Discount / 100;
        }
    }
}