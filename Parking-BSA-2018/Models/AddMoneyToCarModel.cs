using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingBSA2018.Models
{
    public class AddMoneyToCarModel
    {
        public Guid carId { get; set; }
        public double Money { get; set; }
    }
}
