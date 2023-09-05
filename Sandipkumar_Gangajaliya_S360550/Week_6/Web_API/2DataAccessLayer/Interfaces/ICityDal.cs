using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface ICityDal
    {
        // Getters
        CityModel? GetById(int CityId);
        List<CityModel> GetAll();

        // Actions
        int CreateCity(CityModel City);
        void UpdateCity(CityModel City);
        void DeleteCity(int CityId);
    }
}
