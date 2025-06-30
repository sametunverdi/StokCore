using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokCore.BusinessLayer.Concrete;
using StokCore.DataAccessLayer.EntityFramework;
using StokCore.EntityLayer.Concrete;

namespace StokCore.WebUI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public IActionResult Index()
        {
            var values = customerManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            customerManager.TAdd(customer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            customerManager.TUpdate(customer);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var values = customerManager.TGetById(id);
            customerManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
