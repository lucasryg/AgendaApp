public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<T?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task<T> AddAsync(T entity) => await _repository.AddAsync(entity);
    public async Task<T?> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
    public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
}
