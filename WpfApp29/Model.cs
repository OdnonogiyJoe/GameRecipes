using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp29
{
    public class Model
    {
        Inventory inventory = new Inventory();
        RecipeBook recipeBook = new RecipeBook();

        public event EventHandler ItemsChanged;

        internal ObservableCollection<Item> GetItems()
        {
            return new ObservableCollection<Item>(inventory.Items);
        }

        /*internal bool CanFirstToSecond(Item firstItem, Item secondItem)
        {
            if (firstItem.Name == secondItem.Name)
            {
                System.Windows.MessageBox.Show("Нельзя");
                return false;
            }
            return true;
        }*/


        internal bool TryJoin(Item firstItem, Item secondItem)
        {
            if (recipeBook.CanJoin(firstItem, secondItem))
            {
                inventory.DecrementItem(firstItem);
                inventory.DecrementItem(secondItem);
                Item newItem = recipeBook.Join(firstItem, secondItem);
                AddItem(newItem);
                return true;
            }
            else if (firstItem.Name == secondItem.Name)
            {
                System.Windows.MessageBox.Show("Нельзя соединять одинаковые предметы!");
                return false;
            }
            return false;
        }

        internal void AddItem(Item item)
        {
            inventory.IncrementItem(item);
            ItemsChanged?.Invoke(this, null);
        }
    }
}