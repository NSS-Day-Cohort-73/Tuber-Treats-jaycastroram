using Microsoft.AspNetCore.Mvc;
using TuberTreats.Models;

namespace TuberTreats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TuberToppingsController : ControllerBase
    {
        public static List<TuberTopping> TuberToppingsList;

        static TuberToppingsController()
        {
            TuberToppingsList = new List<TuberTopping>
            {
                new TuberTopping { Id = 1, TuberOrderId = 1, ToppingId = 1 },
                new TuberTopping { Id = 2, TuberOrderId = 1, ToppingId = 2 }
            };
        }

        [HttpGet]
        public ActionResult<List<TuberTopping>> Get()
        {
            return TuberToppingsList;
        }

        [HttpPost]
        public ActionResult<TuberTopping> Post(TuberTopping tuberTopping)
        {
            tuberTopping.Id = TuberToppingsList.Any() ? TuberToppingsList.Max(tt => tt.Id) + 1 : 1;
            TuberToppingsList.Add(tuberTopping);
            return CreatedAtAction(nameof(Get), new { id = tuberTopping.Id }, tuberTopping);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tuberTopping = TuberToppingsList.FirstOrDefault(tt => tt.Id == id);
            if (tuberTopping == null)
            {
                return NotFound();
            }

            TuberToppingsList.Remove(tuberTopping);
            return NoContent();
        }
    }
} 