namespace _1CommonInfrastructure.Models
{
    public class CarModel
    {
        public int CarId { get; set; } // int
        public string CarCompanyName { get; set; } // nvarchar(50)
        public string CarModelName { get; set; } // nvarchar(50)
        public string CarType { get; set; } // nvarchar(10)
        public int CarBuildYear { get; set; } // int
        public string CarColour { get; set; } // nvarchar(10)
        public int CarOdometer { get; set; } // int
        public int CarSeat { get; set; } // int
        public int CarRentPrice { get; set; } // int
    }

}
