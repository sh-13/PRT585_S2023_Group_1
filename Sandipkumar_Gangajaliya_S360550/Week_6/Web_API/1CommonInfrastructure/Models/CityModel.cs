using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace _1CommonInfrastructure.Models
{
    public class CityModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}