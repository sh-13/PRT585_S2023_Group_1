using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface ICityService
    {
        Task<CityModel?> GetById(int CityId);
        Task<List<CityModel>> GetAll();

        Task<int> CreateCity(CityModel City);
        Task UpdateCity(CityModel City);
        Task DeleteCity(int CityId);
    }
}
