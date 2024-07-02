using Microsoft.AspNetCore.Mvc;
using TestTask.Interfaces;
using TestTask.Models.Dto;

namespace TestTask.Controllers;
[ApiController]
[Route("[controller]")]
public class ContainersController : ControllerBase
{
    private readonly ILogger<ContainersController> _logger;
    private readonly IContainerService<ContainerDto> _containerService;

    public ContainersController(IContainerService<ContainerDto> containerService, ILogger<ContainersController> logger)
    {
        _containerService = containerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContainerDto>>> GetAllContainers()
    {
        var containers = await _containerService.GetAllAsync();
        return Ok(containers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContainerDto>> GetContainerById(Guid id)
    {
        var container = await _containerService.GetByIdAsync(id);
        if (container == null)
        {
            return NotFound();
        }
        return Ok(container);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateContainer([FromBody] ContainerDto containerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newContainerId = await _containerService.CreateAsync(containerDto);
        return newContainerId;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContainer(Guid id, [FromBody] ContainerDto containerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updatedContainer = await _containerService.UpdateAsync(id, containerDto);
        if (updatedContainer == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContainer(Guid id)
    {
        var success = await _containerService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}