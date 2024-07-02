using Microsoft.AspNetCore.Mvc;
using TestTask.Interfaces;
using TestTask.Models.Dto;

namespace TestTask.Controllers;
[ApiController]
[Route("[controller]")]
public class OperationsController : Controller
{
    private readonly ILogger<OperationsController> _logger;
    private readonly IOperationService<OperationDto> _operationService;

    public OperationsController(IOperationService<OperationDto> operationService, ILogger<OperationsController> logger)
    {
        _operationService = operationService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OperationDto>>> GetAllOperations()
    {
        var operations = await _operationService.GetAllAsync();
        return Ok(operations);
    }

    [HttpGet("by-container/{containerId}")]
    public async Task<ActionResult<IEnumerable<OperationDto>>> GetOperationsByContainerId(Guid containerId)
    {
        var operations = await _operationService.GetByContainerIdAsync(containerId);
        if (operations == null)
        {
            return NotFound();
        }
        return Ok(operations);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOperation([FromBody] OperationDto operationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newOperationId = await _operationService.CreateAsync(operationDto);
        return newOperationId;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OperationDto>> GetOperationById(Guid id)
    {
        var operation = await _operationService.GetByIdAsync(id);
        if (operation == null)
        {
            return NotFound();
        }
        return Ok(operation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOperation(Guid id, [FromBody] OperationDto operationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updatedOperation = await _operationService.UpdateAsync(id, operationDto);
        if (updatedOperation == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOperation(Guid id)
    {
        var success = await _operationService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}