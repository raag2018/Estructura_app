using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estructura_app.Data;
namespace Estructura_app.Controllers{
    public class CustomersController : Controller{
        private readonly OrganizacionContext _context;
        public CustomersController(OrganizacionContext context){
            _context = context;
        }
        public IActionResult Index(){
            var customers = _context.Customers.ToList();
            return View(customers);
        }
        public IActionResult Details(int id){
            var customer = _context.Customers
                .FirstOrDefault(c => c.CustomerId == id);
            if (customer == null){
                return NotFound();
            }
            return View(customer);
        }
        // Métodos para Create, Edit, Delete, etc.
    }
}
