using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public static class CityDtoMapExtensions
    {
        public static CityDto ToCityDto(this CityModel src)
        {
            var dst = new CityDto();
            dst.CityId = src.CityId;
            dst.Name = src.Name;
            dst.State = src.State;
            dst.Country = src.Country;
            
            return dst;
        }

        public static CityModel ToCityModel(this CityDto src)
        {
            var dst = new CityModel();
            dst.CityId = src.CityId;
            dst.Name = src.Name;
            dst.State = src.State;
            dst.Country = src.Country;
            return dst;
        }
    }
}
