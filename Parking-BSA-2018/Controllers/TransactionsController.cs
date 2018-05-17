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

        [HttpGet("/TransactionsLog", Name = "TransactionsLog")]
        [ActionName("TransactionsLog")]
        public IActionResult GetTransactionsLog()
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


        [HttpGet("/LastMinuteTransactions", Name = "LastMinuteTransactions")]
        [ActionName("LastMinuteTransactions")]
        public IActionResult GetLastMinuteTransactions()
        {
           
            var lastMinuteTransactions= ParkingClassLibrary.Parking.Instance.LastMinuteTransactions;
            if (lastMinuteTransactions.Count == 0)
            {
                return BadRequest("There is no last minue Transactions");
            }

            return Ok(lastMinuteTransactions);
        }

        [HttpGet("/LastMinuteTransactionsByCarId", Name = "LastMinuteTransactionsByCarId")]
        [ActionName("LastMinuteTransactionsByCarId")]
        public IActionResult GetLastMinuteTransactionsByCarId(Guid carId)
        {

            var lastMinuteTransactionsByCarId = ParkingClassLibrary.Parking.Instance.LastMinuteTransactions.
                Where(x=>x.CarId==carId).ToList();
            if (lastMinuteTransactionsByCarId.Count == 0)
            {
                return BadRequest("There is no last minue Transactions for selected car");
            }

            return Ok(lastMinuteTransactionsByCarId);
        }
        
        [HttpPut("AddMoneyToCar",Name = "AddMoneyToCar")]
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