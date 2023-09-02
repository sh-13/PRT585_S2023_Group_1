using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string CarCompanyName { get; set; }
        public string CarModelName { get; set; }

    }

    public static class CarDtoMapExtensions
    {
        public static CarDto ToCarDto(this CarModel src)
        {
            var dst = new CarDto();
            dst.CarId = src.CarId;
            dst.CarCompanyName = src.CarCompanyName;
            dst.CarModelName = src.CarModelName;
            return dst;
        }

        public static CarModel ToCarModel(this CarDto src)
        {
            var dst = new CarModel();
            dst.CarId = src.CarId;
            dst.CarCompanyName = src.CarCompanyName;    
            dst.CarModelName = src.CarModelName;
            return dst;
        }
    }
}
