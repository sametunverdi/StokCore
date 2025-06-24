using Microsoft.AspNetCore.Mvc;
using StokCore.BusinessLayer.Concrete;
using StokCore.DataAccessLayer.EntityFramework;
using StokCore.EntityLayer.Concrete;

namespace StokCore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var values = categoryManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {  
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            categoryManager.TAdd(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryManager.TUpdate(category);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.TGetById(id);
            categoryManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
