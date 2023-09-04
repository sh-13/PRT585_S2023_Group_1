using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IBikeService
    {
        Task<BikeModel?> GetById(int BikeId);
        Task<List<BikeModel>> GetAll();

        Task<int> CreateBike(BikeModel Bike);
        Task UpdateBike(BikeModel Bike);
        Task DeleteBike(int BikeId);
    }
}
