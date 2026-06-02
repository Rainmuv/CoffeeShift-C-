using Abstractions;
using Services;

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
        public bool CheckIngredients(List<MenuItem> app)
        {
            foreach (var item in Items)
            {
                if(item.Equals(app)) return false;
            }
            return true;
        }
    }
}