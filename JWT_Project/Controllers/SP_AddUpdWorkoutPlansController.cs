using AutoMapper;
using JWT_Project.Model.Domain;
using JWT_Project.Model.Dto;
using JWT_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SP_AddUpdWorkoutPlansController : ControllerBase
    {
        private readonly ISP_AddUpdWorkoutPlansRepository repository;
        private readonly IMapper mapper;

        public SP_AddUpdWorkoutPlansController(ISP_AddUpdWorkoutPlansRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]

        public async Task<IActionResult> getasync(SP_AddUpdWorkoutPlans input)
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
