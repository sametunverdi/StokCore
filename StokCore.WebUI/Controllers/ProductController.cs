using Microsoft.AspNetCore.Mvc;
using StokCore.BusinessLayer.Concrete;
using StokCore.DataAccessLayer.EntityFramework;
using StokCore.EntityLayer.Concrete;

namespace StokCore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            ViewBag.Categories = categoryManager.TGetList();
            var values = productManager.TGetProductWithCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productManager.TAdd(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            productManager.TUpdate(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = productManager.TGetById(id);
            productManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
