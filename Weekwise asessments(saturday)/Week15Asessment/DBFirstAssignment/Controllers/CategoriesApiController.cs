using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.DTOs;
using NorthwindAPI.Interfaces;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoriesApiController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _repo.GetAllAsync();

            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(result);
        }
    }
}