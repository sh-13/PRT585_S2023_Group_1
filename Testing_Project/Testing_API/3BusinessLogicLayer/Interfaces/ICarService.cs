using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface ICarService
    {
        Task<CarModel?> GetById(int CarId);
        Task<List<CarModel>> GetAll();

        Task<int> CreateCar(CarModel Car);
        Task UpdateCar(CarModel Car);
        Task DeleteCar(int CarId);
    }
}
