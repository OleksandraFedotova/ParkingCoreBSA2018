using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ParkingBSA2018.Controllers
{
    [Produces("application/json")]
    [Route("api/Parking")]
    public class ParkingController : Controller
    {

        [HttpGet("/FreeSpaces", Name = "FreeSpaces")]
        [Route("api/FreeSpaces")]
        [ActionName("FreeSpaces")]
        [AcceptVerbs("FreeSpaces")]
        public IActionResult GetaFreeSpaces()
        {
            int freespaces = ParkingClassLibrary.Parking.Instance.FreeSpaces;

            return Ok("There is " + freespaces + " places on PArking");
        }

        [HttpGet("/TotalRevenue", Name = "TotalRevenue")]
        [Route("api/TotalRevenue")]
        [ActionName("TotalRevenue")]
        [AcceptVerbs("TotalRevenue")]
        public IActionResult GetTotalRevenue()
        {
            double totalRevenue = ParkingClassLibrary.Parking.Instance.GetTotalRevenue();

            return Ok("Parking total revenue is : " + totalRevenue);
        }

        [HttpGet("/BusySpaces", Name = "BusySpaces")]
        [Route("api/BusySpaces")]
        [ActionName("BusySpaces")]
        [AcceptVerbs("BusySpaces")]
        public IActionResult GetaBusySpaces()
        {
            int freespaces = ParkingClassLibrary.Parking.Instance.CarList.Count;

            return Ok("There is " + freespaces + " places on PArking");
        }

    }
}