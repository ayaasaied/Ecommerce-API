
using EcommerceRepository.Data;
using EcommerceServices.Services;
using EcommereCore.DataModel;
using EcommereCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EcommerceRepository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext db;

        public ProductRepository(EcommerceDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(ProductDto productdto)
        {
            using var dataStream = new MemoryStream();

            await productdto.Image.CopyToAsync(dataStream);
            var product = new Product {
                Name = productdto.Name,
                Categoryid=productdto.Categid,
                Price=productdto.Price,
                Image = dataStream.ToArray(),
                Quantity = productdto.Quantity,

            };
            
            await db.Products.AddAsync(product);
            db.SaveChanges();
            return 1;
            


        }

        public async Task<List<Product>> GetAll()
        {

            List<Product> products = await db.Products.ToListAsync();

         
                return products;
        }

    }
}
