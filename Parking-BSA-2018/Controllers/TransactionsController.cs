using Microsoft.AspNetCore.Mvc;
using ParkingBSA2018.Models;
using System;
using System.Linq;

namespace ParkingBSA2018.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {

        [HttpGet(Name = "TransactionsLog"), Route("TransactionsLog")]
        public IActionResult GetaTransactionsLog()
        {
            string trLog;
            try
            {
                trLog = ParkingClassLibrary.Parking.Instance.ShowTransactionsLog();
            }
            catch
            {
                return BadRequest("There is error while reading Transactions Log file. Maybe its empty or smth else");
            }

            return Ok(trLog);
        }


        [HttpGet(Name = "LastMinuteTransactions"), Route("LastMinuteTransactions")]
        public IActionResult GetaLastMinuteTransactions()
        {
           
            var lastMinuteTransactions= ParkingClassLibrary.Parking.Instance.LastMinuteTransactions;
            if (lastMinuteTransactions.Count == 0)
            {
                return BadRequest("There is no last minue Transactions");
            }

            return Ok(lastMinuteTransactions);
        }

        [HttpGet("{id}",Name = "LastMinuteTransactions"), Route("LastMinuteTransactions")]
        public IActionResult GetaLastMinuteTransactions(Guid carId)
        {

            var lastMinuteTransactionsByCarId = ParkingClassLibrary.Parking.Instance.LastMinuteTransactions.
                Where(x=>x.CarId==carId).ToList();
            if (lastMinuteTransactionsByCarId.Count == 0)
            {
                return BadRequest("There is no last minue Transactions for selected car");
            }

            return Ok(lastMinuteTransactionsByCarId);
        }

        [HttpPut(Name = "AddMoneyToCar"), Route("AddMoneyToCar")]
        public IActionResult AddMoneyToCar(AddMoneyToCarModel model )
        {

            try
            {
                ParkingClassLibrary.Parking.Instance.AddMoneyToCar(model.carId, model.Money);
            }
            catch
            {
                return BadRequest("Failed to add money to car");
            }

            return Ok();
        }


    }
}