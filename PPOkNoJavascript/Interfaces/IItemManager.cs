using PPOkNoJavascript.Models;
using PPOkNoJavascript.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPOkNoJavascript.Interfaces
{
    public interface IItemManager
    {
        Item GetItem(int id);
        ItemDetailsViewModel GetAllItems();
        Item Add(Item item);
        Item Update(Item item);
        Item Delete(int id);
    }
}
