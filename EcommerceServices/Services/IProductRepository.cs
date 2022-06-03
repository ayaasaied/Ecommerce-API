


using EcommereCore.DataModel;
using EcommereCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceServices.Services
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<int> Create(ProductDto productdto);
    }
}
