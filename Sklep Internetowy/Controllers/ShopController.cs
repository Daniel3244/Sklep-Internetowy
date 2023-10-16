using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Sklep_Internetowy.Models;

namespace Sklep_Internetowy.Controllers
{
    public class ShopController : Controller
    {
        private static IList<Products> products = new List<Products>
        {
            new Products() {ProductId = 1, Name = "Monitor", Description = "Monitor komputerowy 24 cale", Price = 599},
            new Products() {ProductId = 2, Name = "Klawiatura", Description = "Klawiatura do gier", Price = 199},
            new Products() {ProductId = 3, Name = "Myszka", Description = "Myszka komputerowa", Price = 149},
        };
        // GET: ShopController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            return View(products.FirstOrDefault(x=>x.ProductId==id));
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
            return RedirectToAction("Index");
 
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products editedProduct)
        {
            var existingProduct = products.FirstOrDefault(x=>x.ProductId==editedProduct.ProductId);
            existingProduct.Name = editedProduct.Name;
            existingProduct.Description = editedProduct.Description;
            existingProduct.Price = editedProduct.Price;
            return RedirectToAction("Index");
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
          var product = products.FirstOrDefault(x => x.ProductId == id);
          products.Remove(product);
          return RedirectToAction("Index");
        }
    }
}
