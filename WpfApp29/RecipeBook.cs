using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp29
{
    public class RecipeBook
    {
        Dictionary<(string, string), string> recipes = new Dictionary<(string, string), string>();

        internal bool CanJoin(Item firstItem, Item secondItem)
        {
            if (firstItem == secondItem && firstItem.Count < 2)
                return false;
            var key1 = (firstItem.Name, secondItem.Name);
            var key2 = (secondItem.Name, firstItem.Name);
            return recipes.ContainsKey(key1) || recipes.ContainsKey(key2);
                
        }

        

        internal Item Join(Item firstItem, Item secondItem)
        {
            var key1 = (firstItem.Name, secondItem.Name);
            var key2 = (secondItem.Name, firstItem.Name);
            if (recipes.ContainsKey(key1))
                return new Item { Name = recipes[key1] };
            else
                return new Item { Name = recipes[key2] };
        }

        public RecipeBook()
        {
            recipes.Add(("Корень имбиря", "Шкура с жопы дракона"), "Спирт");
            recipes.Add(("Спирт", "Спирт"), "Двойной спирт");
            recipes.Add(("Спирт", "Шкура с жопы дракона"), "Гимли");
            recipes.Add(("Спирт", "Гимли"), "Пьяный Гимли");
        }
    }
}
