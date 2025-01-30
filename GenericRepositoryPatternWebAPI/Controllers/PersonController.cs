using GenericRepositoryPatternWebAPI.Entities;
using GenericRepositoryPatternWebAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPatternWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person> _repository;

        public PersonController(IRepository<Person> repository) => _repository = repository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            return Ok(result.Take(50));
        }
    }
}
