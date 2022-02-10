using Loyalty.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    public class ProductsController : Controller
    {
        public static List<Product> Product = new List<Product>();

        private readonly MyDbContext _context;

        public ProductsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {

            if (ModelState.IsValid)
            {
                //_context.Product.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product obj = _context.Product.Include(item => item.Category).FirstOrDefault(item => item.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            //SelectList objCategory = new SelectList(_context.Category, "Id", "Name", obj.Category.Id);
            //ViewData["CategoryOptions"] = objCategory;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product obj)
        {
            if (ModelState.IsValid)
            {
                //_context.Product.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product obj = _context.Product.Include(item => item.Category).FirstOrDefault(item => item.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Product obj = _context.Product.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            //_context.Product.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
