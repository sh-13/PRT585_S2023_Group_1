using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Bike
    {
        public int BikeId { get; set; } // int
        public string BikeCompanyName { get; set; } // nvarchar(400)
        public string BikeModelName { get; set; } // nvarchar(400)
        
    }
}
