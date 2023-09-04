using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class BikeDto
    {
        public int BikeId { get; set; }
        public string BikeCompanyName { get; set; }
        public string BikeModelName { get; set; }

    }

    public static class BikeDtoMapExtensions
    {
        public static BikeDto ToBikeDto(this BikeModel src)
        {
            var dst = new BikeDto();
            dst.BikeId = src.BikeId;
            dst.BikeCompanyName = src.BikeCompanyName;
            dst.BikeModelName = src.BikeModelName;
            return dst;
        }

        public static BikeModel ToBikeModel(this BikeDto src)
        {
            var dst = new BikeModel();
            dst.BikeId = src.BikeId;
            dst.BikeCompanyName = src.BikeCompanyName;    
            dst.BikeModelName = src.BikeModelName;
            return dst;
        }
    }
}
