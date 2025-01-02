using Microsoft.AspNetCore.Mvc;
using TuberTreats.Models;

namespace TuberTreats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        public static List<Customer> CustomersList;

        static CustomersController()
        {
            CustomersList = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe", Address = "123 Main St" }
            };
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return CustomersList;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = CustomersList.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            var orders = TuberOrdersController.OrdersList.Where(o => o.CustomerId == id).ToList();
            customer.TuberOrders = orders;

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            customer.Id = CustomersList.Any() ? CustomersList.Max(c => c.Id) + 1 : 1;
            CustomersList.Add(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = CustomersList.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            CustomersList.Remove(customer);
            return NoContent();
        }
    }
} 