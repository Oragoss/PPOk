using PPOkNoJavascript.Data;
using PPOkNoJavascript.Interfaces;
using PPOkNoJavascript.Models;
using PPOkNoJavascript.ViewModels;

namespace PPOkNoJavascript.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly ApplicationDbContext context;

        public ItemManager(ApplicationDbContext context)
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
            if (item != null)
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
            return item;
        }

        public ItemDetailsViewModel GetAllItems()
        {
            var items = context.Items;
            ItemDetailsViewModel model = new ItemDetailsViewModel()
            {
                Items = items,
                PageTitle = "Charges"
            };


            return model;
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
