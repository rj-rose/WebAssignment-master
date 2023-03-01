using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAssignment.Data;
using WebAssignment.Models;

namespace Assignment1.Controllers
{
    public class ItemController : Controller
    {
        private WebAssignmentContext _itemContext { get; set; }

        public ItemController(WebAssignmentContext ctx)
        {
            _itemContext = ctx;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index(int id)
        {
            var item = _itemContext.Items;
                     
            return View(item);
        }
        public IActionResult Details(int id)
        {
            var item = _itemContext.Items
                     .FirstOrDefault(i => i.ItemId == id);
            return View(item);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Title = "Add Item";
            ViewBag.Items = _itemContext.Items.
                                 OrderBy(c => c.ItemName).ToList();

            return View("Edit", new Item());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Items = _itemContext.Items.
                                 OrderBy(i => i.ItemName).ToList();

            var item = _itemContext.Items
                        .FirstOrDefault(i => i.ItemId == id);

            return View(item);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _itemContext.Items
                        .FirstOrDefault(i => i.ItemId == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item i)
        {
            string action = (i.ItemId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    i.AuctionStart = DateTime.Now;
                    _itemContext.Items.Add(i);
                }
                else if (action == "Edit")
                {

                    i.AuctionStart = DateTime.Now;
                    _itemContext.Items.Update(i);
                }
                
                _itemContext.SaveChanges();
                return RedirectToAction("Index", "Item");

            }
            else
            {
                // fail validation
                ViewBag.Action = "Add";
                return View(i);
            }
        }
        
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var item = _itemContext.Items
                        .FirstOrDefault(i => i.ItemId == id);
            
            if (item != null)
            {
                _itemContext.Items.Remove(item);
                _itemContext.SaveChanges();
            }
            
            return RedirectToAction("Index", "Item");
        }
    }
}
