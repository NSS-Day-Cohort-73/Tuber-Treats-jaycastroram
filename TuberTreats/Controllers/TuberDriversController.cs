using Microsoft.AspNetCore.Mvc;
using TuberTreats.Models;

namespace TuberTreats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TuberDriversController : ControllerBase
    {
        public static List<TuberDriver> DriversList;

        static TuberDriversController()
        {
            DriversList = new List<TuberDriver>
            {
                new TuberDriver { Id = 1, Name = "Bob Smith" }
            };
        }

        [HttpGet]
        public ActionResult<List<TuberDriver>> Get()
        {
            return DriversList;
        }

        [HttpGet("{id}")]
        public ActionResult<TuberDriver> GetById(int id)
        {
            var driver = DriversList.FirstOrDefault(d => d.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            var deliveries = TuberOrdersController.OrdersList.Where(o => o.TuberDriverId == id).ToList();
            driver.TuberDeliveries = deliveries;

            return driver;
        }
    }
} 