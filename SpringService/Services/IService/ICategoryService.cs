using SpringService.Models;

namespace SpringService.Services.IService
{
    interface ICategoryService
    {
        Task<List<Category>> GetPopularServices();
    }
}
