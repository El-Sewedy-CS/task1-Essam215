using Demo_2.Models;
using Demo_2.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Demo_2.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemRepo _menuItemRepo;
        public MenuItemController(IMenuItemRepo menuItemRepo)
        {
            _menuItemRepo = menuItemRepo;
        }
        public IActionResult Index()
        {
            var menuItems = _menuItemRepo.GetAll();
            return View(menuItems);
        }
        [HttpPost]
        public IActionResult GetAll()
        {
            var menuItems = _menuItemRepo.GetAll();
            return View(menuItems);
        }
        [HttpPost]
        public IActionResult Add(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemRepo.Add(menuItem);
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }
        [HttpPost]
        public IActionResult Update(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemRepo.Update(menuItem);
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }
        [HttpPost]
        public IActionResult Delete(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemRepo.Delete(menuItem.Id);
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }
    }
}
