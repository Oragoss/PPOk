using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPOkNoJavascript.Interfaces;
using PPOkNoJavascript.Models;
using PPOkNoJavascript.ViewModels;
using System;

namespace PPOkNoJavascript.Controllers
{
    public class ItemController : Controller
    {
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

        [HttpPost]
        public IActionResult Create(Item item)
        {
            item.TransactionDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                itemManager.Add(item);
            }

            return Redirect("/Item");
        }
    }
}
