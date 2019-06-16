using PPOkNoJavascript.Models;
using System.Collections.Generic;
using System.Linq;

namespace PPOkNoJavascript.ViewModels
{
    public class ItemDetailsViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public string PageTitle { get; set; }
        public Item Item { get; set; } 
    }
}
