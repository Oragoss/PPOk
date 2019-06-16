using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPOkNoJavascript.Interfaces;
using PPOkNoJavascript.Models;
using PPOkWithJavascript.Data;

namespace PPOkWIthJavascript.Controllers
{
    
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemManager itemManager;

        public ItemController(IItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        [Route("api/GetData")]
        [HttpGet]
        public string GetData()
        {
            string item = itemManager.GetAllItems();

            return item;
        }

        [Route("api/PostData")]
        [HttpPost]
        public async Task<ActionResult<Item>> PostData(Item item)
        {
            itemManager.Add(item);

            return Ok();
        }
    }
}