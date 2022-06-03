

using EcommereCore.DataModel;
using EcommereCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceServices.Services
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        //Task<Category> GetById(int id);
        //Task<Category> GetByName(string name);
        Task<int> add (CtegoryDto category);
        Task<bool> Isvalidtype(int id);

        //Task<Category> update (Category category);  

    }
}
