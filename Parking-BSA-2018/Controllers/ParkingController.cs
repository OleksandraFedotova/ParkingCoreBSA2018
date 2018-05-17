using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ParkingBSA2018.Controllers
{
    [Produces("application/json")]
    [Route("api/Parking")]
    public class ParkingController : Controller
    {

        [HttpGet(Name = "FreeSpaces"), Route("FreeSpaces")]
        public IActionResult GetaFreeSpaces()
        {
            int freespaces =  ParkingClassLibrary.Parking.Instance.FreeSpaces;

            return Ok("There is "+freespaces+" places on PArking");
        }

        [HttpGet(Name = "TotalRevenue"), Route("TotalRevenue")]
        public IActionResult GetTotalRevenue()
        {
            double totalRevenue = ParkingClassLibrary.Parking.Instance.GetTotalRevenue();

            return Ok("Parking total revenue is : "+ totalRevenue);
        }

        [HttpGet(Name = "BusySpaces"), Route("BusySpaces")]
        public IActionResult GetaBusySpaces()
        {
            int freespaces = ParkingClassLibrary.Parking.Instance.CarList.Count;

            return Ok("There is " + freespaces + " places on PArking");
        }

    }
}