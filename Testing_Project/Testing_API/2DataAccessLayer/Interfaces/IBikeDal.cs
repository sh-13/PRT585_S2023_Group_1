using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IBikeDal
    {
        // Getters
        BikeModel? GetById(int BikeId);
        List<BikeModel> GetAll();

        // Actions
        int CreateBike(BikeModel Bike);
        void UpdateBike(BikeModel Bike);
        void DeleteBike(int BikeId);
    }
}
