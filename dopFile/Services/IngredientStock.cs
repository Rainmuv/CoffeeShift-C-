namespace Services
{
    class IngredientStock 
    {
        public Dictionary<string, int> _stock = new Dictionary<string, int>
        {
            { "кофе", 30 },
            { "молоко", 25 },
            { "вода", 50 },
            { "сахар", 40 },
            { "стакан малый", 20 },
            { "стакан большой", 15 },
            { "крышка", 30 },
            { "сироп ванильный", 10 },
            { "сироп карамельный", 10 },
            { "круассан", 8 },
            { "маффин", 6 },
            { "чизкейк", 5 },
            { "брауни", 4 }
        };  
        public Dictionary<string, int> _minStock = new Dictionary<string, int>
        {
            { "кофе", 5 },
            { "молоко", 5 },
            { "стакан малый", 5 },
            { "стакан большой", 5 },
            { "круассан", 2 },
            { "маффин", 2 },
            { "чизкейк", 2 },
            { "брауни", 2 }
        };  
        public bool HasEnough(string key, int value)
        {
            if(_stock.ContainsKey(key) && _stock[key] >= value ) return true;
            return false;
        }
        
    }   
}