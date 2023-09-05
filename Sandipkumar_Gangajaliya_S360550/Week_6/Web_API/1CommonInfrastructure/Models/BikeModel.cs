using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Models
{
    public class BikeModel
    {
        public int BikeId { get; set; } // int
        public string BikeCompanyName { get; set; } // nvarchar(400)
        public string BikeModelName { get; set; } // nvarchar(400)

    }

}
