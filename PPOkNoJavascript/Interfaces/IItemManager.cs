using PPOkNoJavascript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPOkNoJavascript.Interfaces
{
    public interface IItemManager
    {
        Item GetItem(int id);
        IEnumerable<Item> GetAllItems();
        Item Add(Item item);
        Item Update(Item item);
        Item Delete(int id);
    }
}
