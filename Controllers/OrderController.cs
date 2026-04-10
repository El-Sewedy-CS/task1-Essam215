    using Demo_2.Controllers;
    using Demo_2.Models;
    using Demo_2.Repo.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    namespace Demo_2.Controllers
    {
        public class OrderController : Controller
        {
            private readonly IOrderRepo _orderRepo;
            public OrderController(IOrderRepo orderRepo)
            {
                _orderRepo = orderRepo;
            }
            public IActionResult Index()
            {
                var orders = _orderRepo.GetAll();
                return View(orders);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Order order)
            {
                if (ModelState.IsValid)
                {
                    _orderRepo.Add(order);
                    return RedirectToAction("Index");
                }
                return View(order);
            }
        public IActionResult Update(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null) return NotFound();

            return View(order);
        }
        [HttpPost]
            public IActionResult Update(Order order)
            {
                if (ModelState.IsValid)
                {
                    _orderRepo.Update(order);
                    return RedirectToAction("Index");
                }
                return View(order);
            }
        public IActionResult Delete(int id)
        {
            var order = _orderRepo.GetById(id);
            if (order == null) return NotFound();

            return View(order);
        }
        [HttpPost]
             public IActionResult Delete(Order order)
                {
                if (ModelState.IsValid)
                {
                    _orderRepo.Delete(order.Id);
                    return RedirectToAction("Index");
                }
                return View(order);
            }
        }
    }