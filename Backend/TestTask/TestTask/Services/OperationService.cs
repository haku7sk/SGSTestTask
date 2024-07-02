using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Interfaces;
using TestTask.Models.Dbo;
using TestTask.Models.Dto;

namespace TestTask.Services;


public class OperationService<T>:IOperationService<T> where T:OperationDto
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<OperationService<T>> _logger;
    public OperationService(ApplicationDbContext dbContext, IMapper mapper, ILogger<OperationService<T>> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var res = await _dbContext.Operations.AsNoTracking().ToListAsync();
        return  _mapper.Map<List<T>>(res);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var res = await _dbContext.Operations.AsNoTracking().Where(x=>x.ID==id).FirstAsync();
        return  _mapper.Map<T>(res);
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        var newOperation = _mapper.Map<OperationDbo>(entity);
        var res = await _dbContext.Operations.AddAsync(newOperation);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"New operation with Id {res.Entity.ID} Added");

        return res.Entity.ID;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        var operation = new OperationDbo();
        entity.ID = id;
        _mapper.Map(entity, operation); 
        
        var res = _dbContext.Attach(operation);
        _dbContext.Entry(operation).State = EntityState.Modified;
        _dbContext.Entry(operation).Property(x => x.ID).IsModified = false; 
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Operation with Id {id} was updated");

        return _mapper.Map<T>(res.Entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var operation = await _dbContext.Operations.FindAsync(id);
        if (operation == null)
        {
            _logger.LogInformation($"Operation with Id {id} not found, when try deleted");
            return false;
        }

        _dbContext.Operations.Remove(operation);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Operation with Id {id} was deleted");

        return true;
    }

    public async Task<IEnumerable<T>> GetByContainerIdAsync(Guid containerId)
    {
        var res = await _dbContext.Operations.Where(x=>x.ContainerID == containerId).ToListAsync();
        return  _mapper.Map<List<T>>(res);

    }
}
