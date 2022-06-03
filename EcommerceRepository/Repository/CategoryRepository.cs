
using EcommerceRepository.Data;
using EcommerceServices.Services;
using EcommereCore.DataModel;
using EcommereCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceRepository.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly EcommerceDbContext db;
        public CategoryRepository(EcommerceDbContext db)
        {
            this.db = db;
        }

        public async Task<int> add(CtegoryDto categorydto)
        {
            var categoryDto = new Category{ Name= categorydto.Name };
            db.Categories.Add(categoryDto);
            return await db.SaveChangesAsync();          
           
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> Categories = await db.Categories.ToListAsync();
            return Categories;
        }

        public Task<bool> Isvalidtype(int id)
        {
            return db.Categories.AnyAsync(g => g.Id == id);
        }
    }
}
