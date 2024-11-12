namespace ServiceArticles.IRepository;

public interface IRepository<T, TDto> 
    where T : class
    where TDto : class 
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(TDto itemDto, CancellationToken cancellationToken); 
    Task AddRangeAsync(List<TDto> itemDtos, CancellationToken cancellationToken);  
}