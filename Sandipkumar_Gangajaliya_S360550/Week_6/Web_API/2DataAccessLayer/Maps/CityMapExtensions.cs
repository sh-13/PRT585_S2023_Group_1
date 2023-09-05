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
    public static class CityMapExtensions
    {
        public static CityModel ToCityModel(this City src)
        {
            var dst = new CityModel();

            dst.CityId = src.CityId;
            dst.Name = src.Name;
            dst.State = src.State;
            dst.Country = src.Country;

            return dst;
        }

        public static City ToCity(this CityModel src, City dst = null)
        {
            if (dst == null)
            {
                dst = new City();
            }

            dst.CityId = src.CityId;
            dst.Name = src.Name;
            dst.State = src.State;
            dst.Country = src.Country;

            return dst;
        }
    }
}
