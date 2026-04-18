using NorthwindAPI.Models;
using NorthwindAPI.DTOs;

namespace NorthwindAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);

        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}