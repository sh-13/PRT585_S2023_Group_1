using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Car
    {
        public int CarId { get; set; } // int
        public string CarCompanyName { get; set; } // nvarchar(400)
        public string CarModelName { get; set; } // nvarchar(400)
        
    }
}
