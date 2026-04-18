using NorthwindAPI.Models;

namespace NorthwindAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}