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
    public static class BikeMapExtensions
    {
        public static BikeModel ToBikeModel(this Bike src)
        {
            var dst = new BikeModel();

            dst.BikeId = src.BikeId;
            dst.BikeCompanyName = src.BikeCompanyName;
            dst.BikeModelName = src.BikeModelName;

            return dst;
        }

        public static Bike ToBike(this BikeModel src, Bike dst = null)
        {
            if (dst == null)
            {
                dst = new Bike();
            }

            dst.BikeId = src.BikeId;
            dst.BikeCompanyName = src.BikeCompanyName;
            dst.BikeModelName = src.BikeModelName;


            return dst;
        }
    }
}
