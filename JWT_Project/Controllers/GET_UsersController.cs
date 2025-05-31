using AutoMapper;
using JWT_Project.Model.Domain;
using JWT_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GET_UsersController : ControllerBase
    {
        private readonly IGET_UsersRepository repository;
        private readonly IMapper mapper;
        public GET_UsersController(IGET_UsersRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> getasync(GET_UsersDomain input)
        {
            try
            {
                var domain = await repository.getAsync(input);
                var dto = mapper.Map<List<GET_Users>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}