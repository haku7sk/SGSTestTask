using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Interfaces;
using TestTask.Models.Dbo;
using TestTask.Models.Dto;

namespace TestTask.Services;

public class ContainerService<T>:IContainerService<T> where T:ContainerDto
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ContainerService<T>> _logger;
    public ContainerService(ApplicationDbContext dbContext, IMapper mapper, ILogger<ContainerService<T>> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var res = await _dbContext.Containers.AsNoTracking().ToListAsync();
        return  _mapper.Map<List<T>>(res);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var res = await _dbContext.Containers.AsNoTracking().Where(x=>x.ID==id).FirstOrDefaultAsync();
        if (res == null) throw new Exception("Не существует контейнера с заданными Id");
        return  _mapper.Map<T>(res);
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        var newContainer = _mapper.Map<ContainerDbo>(entity);
        var res = await _dbContext.Containers.AddAsync(newContainer);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"New contatiner with Id {res.Entity.ID} Added");

        return res.Entity.ID;
    }

    public async Task<T> UpdateAsync(Guid id, T entity)
    {
        var container = new ContainerDbo();
        entity.ID = id;
        _mapper.Map(entity, container); 
        var res = _dbContext.Attach(container);
        _dbContext.Entry(container).State = EntityState.Modified;
        _dbContext.Entry(container).Property(x => x.ID).IsModified = false; 
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Contatiner with Id {id} was updated");

        return _mapper.Map<T>(res.Entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var container = await _dbContext.Containers.FindAsync(id);
        if (container == null)
        {
            _logger.LogInformation($"Contatiner with Id {id} not found, when try deleted");
            return false;
        }

        _dbContext.Containers.Remove(container);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation($"Contatiner with Id {id} was deleted");

        return true;
    }
}
