using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace _1CommonInfrastructure.Models
{
	public class AddressModel
	{
        public int AddressId { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}