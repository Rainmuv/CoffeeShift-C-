using Models;
using Services;
using Abstractions;
class Program
{
    static void Main()
    {
        var espresso = new Drink() { Name = "Эспрессо", BasePrice = 35, Volume = 60, Strength = 3,
            Ingredients = new Dictionary<string, int> { {"кофе",2}, {"вода",1}, {"стакан малый",1}}};

        var americano = new Drink( ) {Name = "Американо", BasePrice = 40, Volume = 200, Strength = 2,
            Ingredients = new Dictionary<string, int> { {"кофе",2}, {"вода",2}, {"стакан большой",1}, {"крышка",1} }};

        var cappuccino = new Drink( ) {Name = "Капучино",  BasePrice = 45, Volume = 200, Strength = 2,
            Ingredients = new Dictionary<string, int> { {"кофе",2}, {"молоко",2}, {"вода",1}, {"стакан большой",1}, {"крышка",1} }};

        var latteVanilla = new Drink( ) {Name = "Латте ванильный", BasePrice = 55, Volume = 250, Strength = 1,
            Ingredients = new Dictionary<string, int> { {"кофе",2}, {"молоко",3}, {"сироп ванильный",1}, {"стакан большой",1}, {"крышка",1} }};

        var rafCaramel = new Drink( ) {Name = "Раф карамельный", BasePrice = 60, Volume = 250, Strength = 1,
            Ingredients = new Dictionary<string, int> { {"кофе",2}, {"молоко",3}, {"сироп карамельный",1}, {"стакан большой",1}, {"крышка",1} }};
        
        var croissant = new Dessert { Name = "Круассан", BasePrice = 30, Freshness = 5,
            Ingredients = new Dictionary<string, int> { {"круассан",1} }};

        var muffin = new Dessert { Name = "Маффин", BasePrice = 25, Freshness = 4,
            Ingredients = new Dictionary<string, int> { {"маффин",1} }};

        var cheesecake = new Dessert { Name = "Чизкейк", BasePrice = 45, Freshness = 3,
            Ingredients = new Dictionary<string, int> { {"чизкейк",1} }};

        var brownie = new Dessert { Name = "Брауни", BasePrice = 40, Freshness = 2,
            Ingredients = new Dictionary<string, int> { {"брауни",1} }};

        var comboMorning = new Combo(cappuccino, croissant, 10) { Name = "Утро", Discount = 10,
            };

        var comboSweet = new Combo(latteVanilla, cheesecake, 12) { Name = "Сладкий перерыв", Discount = 12,
            };

        var comboFast = new Combo(espresso, muffin, 8) { Name = "Быстрый заряд", Discount = 8,
            };

        var customers = new List<Customer>
            {
                new Customer("Анна", "New", 0),
                new Customer("Максим", "Regular", 3),
                new Customer("Ирина", "Vip", 8)
            };

        List<MenuItem> allProducts = new List<MenuItem>
        {
            espresso,
            americano,
            cappuccino,
            latteVanilla,
            rafCaramel,
            croissant,
            muffin,
            cheesecake,
            brownie,
            comboMorning,
            comboSweet,
            comboFast
        };

        ShiftReport report = new ShiftReport();
        CafeMenu a = new CafeMenu(allProducts);

        var b = new CafeApplication(a, new IngredientStock(), customers, report);
        b.Run();
    }
}   