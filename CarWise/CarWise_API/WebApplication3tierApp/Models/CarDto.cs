using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string CarCompanyName { get; set; }
        public string CarModelName { get; set; }
        public string CarType { get; set; }
        public int CarBuildYear { get; set; }
        public string CarColour { get; set; }
        public int CarOdometer { get; set; }
        public int CarSeat { get; set; }
        public int CarRentPrice { get; set; }
    }

    public static class CarDtoMapExtensions
    {
        public static CarDto ToCarDto(this CarModel src)
        {
            var dst = new CarDto();
            dst.CarId = src.CarId;
            dst.CarCompanyName = src.CarCompanyName;
            dst.CarModelName = src.CarModelName;
            dst.CarType = src.CarType;
            dst.CarBuildYear = src.CarBuildYear;
            dst.CarColour = src.CarColour;
            dst.CarOdometer = src.CarOdometer;
            dst.CarSeat = src.CarSeat;
            dst.CarRentPrice = src.CarRentPrice;
            return dst;
        }

        public static CarModel ToCarModel(this CarDto src)
        {
            var dst = new CarModel();
            dst.CarId = src.CarId;
            dst.CarCompanyName = src.CarCompanyName;    
            dst.CarModelName = src.CarModelName;
            dst.CarType = src.CarType;
            dst.CarBuildYear = src.CarBuildYear;
            dst.CarColour = src.CarColour;
            dst.CarOdometer = src.CarOdometer;
            dst.CarSeat = src.CarSeat;
            dst.CarRentPrice = src.CarRentPrice;
            return dst;
        }
    }
}
