using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public static class AddressDtoMapExtensions
    {
        public static AddressDto ToAddressDto(this AddressModel src)
        {
            var dst = new AddressDto();
            dst.AddressId = src.AddressId;
            dst.Unit = src.Unit;
            dst.Street = src.Street;
            dst.Suburb = src.Suburb;
            dst.State = src.State;
            dst.Country = src.Country;
            
            return dst;
        }

        public static AddressModel ToAddressModel(this AddressDto src)
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
    }
}
