using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
	public static class AddressMapExtensions
	{
        public static AddressModel ToAddressModel(this Address src)
        {
            var dst = new AddressModel();

            dst.AddressId = src.AddressId;
            dst.Unit = src.Unit;
            dst.Street = src.Street;
            dst.Suburb = src.Suburb;
            dst.State = src.State;
            dst.Country = src.Country;

            return dst;
        }

        public static Address ToAddress(this AddressModel src, Address dst = null)
        {
            if (dst == null)
            {
                dst = new Address();
            }

            dst.AddressId = src.AddressId;
            dst.Unit = src.Unit;
            dst.Street = src.Street;
            dst.Suburb = src.Suburb;
            dst.State = src.State;
            dst.Country = src.Country;


            return dst;
        }
    }
}