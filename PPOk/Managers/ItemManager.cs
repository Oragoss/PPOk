using PPOk.Interfaces;
using PPOk.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPOk.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly ItemDbContext context;

        public ItemManager(ItemDbContext context)
        {
            this.context = context;
        }

        public Item Add(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }

        public Item Delete(int id)
        {
            var item = context.Items.Find(id);
            if(item != null)
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
            return item;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return context.Items;
        }

        public Item GetItem(int id)
        {
            return context.Items.Find(id);
        }

        public Item Update(Item item)
        {
            var newItem = context.Items.Attach(item);
            newItem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return item;
        }
    }
}
