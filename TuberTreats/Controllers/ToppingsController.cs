using Microsoft.AspNetCore.Mvc;
using TuberTreats.Models;

namespace TuberTreats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToppingsController : ControllerBase
    {
        public static List<Topping> ToppingsList;

        static ToppingsController()
        {
            ToppingsList = new List<Topping>
            {
                new Topping { Id = 1, Name = "Cheese" },
                new Topping { Id = 2, Name = "Bacon" },
                new Topping { Id = 3, Name = "Sour Cream" }
            };
        }

        [HttpGet]
        public ActionResult<List<Topping>> Get()
        {
            return ToppingsList;
        }

        [HttpGet("{id}")]
        public ActionResult<Topping> GetById(int id)
        {
            var topping = ToppingsList.FirstOrDefault(t => t.Id == id);
            if (topping == null)
            {
                return NotFound();
            }
            return Ok(topping);
        }
    }
} 