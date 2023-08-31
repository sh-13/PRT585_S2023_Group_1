using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Models
{
    public class CarModel
    {
        public int CarId { get; set; } // int
        public string CarCompanyName { get; set; } // nvarchar(400)
        public string CarModelName { get; set; } // nvarchar(400)

    }

}
