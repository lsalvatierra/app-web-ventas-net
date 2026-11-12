using app_web_ventas.Data;
using app_web_ventas.Models;
using Microsoft.EntityFrameworkCore;

namespace app_web_ventas.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            //Select * from categories
            return await _appDbContext.Categories.ToListAsync();
        }
    }
}
