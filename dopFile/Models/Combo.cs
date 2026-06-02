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
        public bool CheckIngredients(IngredientStock stock)
        {
            foreach (var item in Items)
            {
                if(item is Drink ax )
                {
                    if(!ax.CheckIngredients(new IngredientStock()))
                    {   
                        return false;
                    }
                } else if (item is Dessert al)
                {
                    if(!al.CheckIngredients(new IngredientStock()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}