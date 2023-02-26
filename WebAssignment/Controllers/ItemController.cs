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
            ViewBag.Items = _itemContext.Items.
                                 OrderBy(i => i.ProductName).ToList();

            return View("Edit", new Item());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Items = _itemContext.Items.
                                 OrderBy(i => i.ProductName).ToList();

            var item = _itemContext.Items
                        .FirstOrDefault(i => i.ItemId == id);

            return View(item);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _itemContext.Items
                        .FirstOrDefault(c => c.ItemId == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item i)
        {
            string action = (i.ItemId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                // pass validation
                if (action == "add")
                {
                    i.AuctionStartDate = DateTime.Now;
                    _itemContext.Items.Add(i);
                }
                else
                {
                    _itemContext.Items.Update(i);
                }

                _itemContext.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                // fail validation
                ViewBag.Action = action;
                ViewBag.Categories = _itemContext.Items.
                                     OrderBy(i => i.ProductName).ToList();

                return View(i);
            }
        }
        
        [HttpPost]
        public IActionResult Delete(Item c)
        {
            _itemContext.Items.Remove(c);
            _itemContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
