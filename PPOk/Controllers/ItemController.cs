using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PPOk.Interfaces;
using PPOk.Models;
using PPOk.ViewModels;

namespace PPOk.Controllers
{
    public class ItemController : Controller
    {
        //START HERE: https://www.youtube.com/watch?v=qJmEI2LtXIY
        //May need to go back a couple of videos
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
            //var model = itemManager.GetItem(1);
            //ViewBag.PageTitle = "Employee Details";
            //return View(model);

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
            if(ModelState.IsValid)
            {
                Item newItem = itemManager.Add(item);
            }

            return View();
        }
    }
}