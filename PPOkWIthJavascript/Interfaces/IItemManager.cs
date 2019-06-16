using PPOkNoJavascript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPOkNoJavascript.Interfaces
{
    public interface IItemManager
    {
        string GetAllItems();
        void Add(Item item);
    }
}
