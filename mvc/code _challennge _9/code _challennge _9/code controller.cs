using System.Linq;
using System.Web.Mvc;
using CodeChallenge9.Models; 

namespace CodeChallenge9.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public ActionResult GermanCustomers()
        {
            var customers = db.Customers
                .Where(c => c.Country == "Germany")
                .ToList();

            return View(customers);
        }

        public ActionResult CustomerByOrder(int id)
        {
            var customer = db.Orders
                .Where(o => o.OrderID == id)
                .Select(o => o.Customer)
                .FirstOrDefault();

            return View(customer);
        }
    }
}
