using Microsoft.AspNetCore.Mvc;
using ParkingBSA2018.Models;
using ParkingClassLibrary;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace ParkingBSA2018.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
    public class CarsController : Controller
    {

        [HttpPost(Name ="AddCar")]
        public IActionResult AddCar(AddCarModel carModel)
        {
            var carToAdd = new Car(

               carModel.balance,
               (CarType)Enum.Parse(typeof(CarType), carModel.carType)
            );

            try
            {
                ParkingClassLibrary.Parking.Instance.AddCar(carToAdd);
            }
            catch
            {
                return BadRequest("Cannot  add Car, please check the input.");
            }

            return Ok();
        }


        [HttpDelete("{id}", Name ="RemoveCarById")]
        public IActionResult RemoveCar([FromQuery]Guid carId)
        {
            try
            {
                var carToRemove = Parking.Instance.GetCarById(carId);
                Parking.Instance.RemoveCar(carToRemove);
            }
            catch
            {
                return BadRequest("There is no car with specified ID");
            }

            return Ok();
        }

        [HttpGet(Name ="GetAllCars")]
        [SwaggerOperation("GetAllCars")]
        public IActionResult GetAllCars()
        {
            var carList = Parking.Instance.CarList;

            if (carList.Count==0)
            {
                return BadRequest("CarList is empty");
            }
            return Ok(carList);
        }

        [HttpGet("{id}",Name = "GetCarById")]
        public IActionResult GetCarById([FromHeader]Guid carId)
        {
            Car car;

            try
            {
                car = Parking.Instance.GetCarById(carId);
            }
            catch
            {
                return BadRequest("there is no car with specified Id");
            } 
            
            return Ok(car);
        }
    }
}