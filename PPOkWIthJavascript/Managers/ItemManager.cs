using Newtonsoft.Json;
using PPOkNoJavascript.Interfaces;
using PPOkNoJavascript.Models;
using PPOkWithJavascript.Data;
using System.Collections.Generic;

namespace PPOkNoJavascript.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly ApplicationDbContext context;

        public ItemManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Item item)
        {
            context.Add(item);
            context.SaveChangesAsync();
        }
        
        public string GetAllItems()
        {
            var items = context.Set<Item>();
            string json = JsonConvert.SerializeObject(items);

            return json;
        }
    }
}
