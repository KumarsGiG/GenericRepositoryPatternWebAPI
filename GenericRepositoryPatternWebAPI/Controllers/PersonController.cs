using GenericRepositoryPatternWebAPI.Entities;
using GenericRepositoryPatternWebAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPatternWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController(IRepository<Person> repository, ILogger<PersonController> logger) : ControllerBase
    {
        private readonly IRepository<Person> _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        private readonly ILogger<PersonController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            _logger.LogInformation(await Task.FromResult($"Generated {result.Count()} person(s) records."));
            return Ok(result.Take(50));
        }
    }
}
