using AutoMapper;
using JWT_Project.Data;
using JWT_Project.Model.Domain;
using JWT_Project.Model.Dto;
using JWT_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SP_DeleteRolesController : ControllerBase
    {
        private readonly ISP_DeleteRolesRepository repository;
        private readonly IMapper mapper;
        public SP_DeleteRolesController(ISP_DeleteRolesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> getasync(SP_DeleteRoles input)
        {
            try
            {
                var domain = await repository.getasync(input);
                var dto = mapper.Map<List<ApiResponseMessageDto>>(domain);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }
    }
}