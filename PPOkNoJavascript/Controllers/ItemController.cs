using Microsoft.AspNetCore.Mvc;
using PPOkNoJavascript.Interfaces;
using PPOkNoJavascript.Models;
using PPOkNoJavascript.ViewModels;

namespace PPOkNoJavascript.Controllers
{
    public class ItemController : Controller
    {
        //START HERE: https://www.youtube.com/watch?v=lhiIvx7jMaY&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=55
        private readonly IItemManager itemManager;

        public ItemController(IItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        //IActionResult
        public ViewResult Index()
        {
            var model = itemManager.GetAllItems();
            return View(model);
        }

        public ViewResult Details(int? id)
        {
            ItemDetailsViewModel itemDetailsViewModel = new ItemDetailsViewModel()
            {
                Item = itemManager.GetItem(id ?? 1),
                PageTitle = "Item Details"
            };

            return View(itemDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                Item newItem = itemManager.Add(item);
            }

            return View();
        }
    }
}
