using Microsoft.AspNetCore.Mvc;
using TuberTreats.Models;

namespace TuberTreats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TuberOrdersController : ControllerBase
    {
        public static List<TuberOrder> OrdersList;

        static TuberOrdersController()
        {
            OrdersList = new List<TuberOrder>
            {
                new TuberOrder 
                { 
                    Id = 1,
                    CustomerId = 1,
                    OrderPlacedOnDate = DateTime.Now,
                    Toppings = new List<Topping>()
                }
            };
        }

        [HttpGet]
        public ActionResult<List<TuberOrder>> Get()
        {
            return OrdersList;
        }

        [HttpGet("{id}")]
        public ActionResult<TuberOrder> GetById(int id)
        {
            var order = OrdersList.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var tuberToppings = TuberToppingsController.TuberToppingsList
                .Where(tt => tt.TuberOrderId == id)
                .Select(tt => ToppingsController.ToppingsList
                    .FirstOrDefault(t => t.Id == tt.ToppingId))
                .Where(t => t != null)
                .ToList();

            order.Toppings = tuberToppings;
            return order;
        }

        [HttpPost]
        public ActionResult<TuberOrder> Post(TuberOrder order)
        {
            order.Id = OrdersList.Any() ? OrdersList.Max(o => o.Id) + 1 : 1;
            order.OrderPlacedOnDate = DateTime.Now;
            OrdersList.Add(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TuberOrder order)
        {
            var existingOrder = OrdersList.FirstOrDefault(o => o.Id == id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.TuberDriverId = order.TuberDriverId;
            existingOrder.Toppings = order.Toppings;

            return NoContent();
        }

        [HttpPost("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var order = OrdersList.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            order.DeliveredOnDate = DateTime.Now;
            return NoContent();
        }
    }
} 