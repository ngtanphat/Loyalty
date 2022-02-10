using Microsoft.AspNetCore.Mvc;
using Loyalty.Data;
using Microsoft.AspNetCore.Http;
using Loyalty.Models;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
            public static List<Category> Category = new List<Category>();

            private readonly MyDbContext _context;

            public CategoriesController(MyDbContext context)
            {
                _context = context;
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Category category)
            {

                if (ModelState.IsValid)
                {
                    //_context.Category.Add(category);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return Ok() ;
            }
            public IActionResult Update(int? Id)
            {
                if (Id == null)
                {
                    return NotFound();
                }
                Category obj = _context.Category.Find(Id);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Update(Category obj)
            {

                if (ModelState.IsValid)
                {
                    //_context.Category.Update(obj);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return Ok();
            }
            public IActionResult Delete(int? Id)
            {

                if (Id == null)
                {
                    return NotFound();
                }
                Category obj = _context.Category.Include(x => x.Products).FirstOrDefault(x => x.Id == Id);
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok();

            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteCategory(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                Category obj = _context.Category.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                //_context.Category.Remove(obj);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
}
