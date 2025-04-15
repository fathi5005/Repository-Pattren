// Domain/Interfaces/IRepository.cs
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}

// Data/Repositories/Repository.cs
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    public Repository(AppDbContext context) => _context = context;

    public async Task<T> GetByIdAsync(int id) 
        => await _context.Set<T>().FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() 
        => await _context.Set<T>().ToListAsync();

    public async Task AddAsync(T entity) 
        => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity) 
        => _context.Set<T>().Update(entity);

    public void Delete(T entity) 
        => _context.Set<T>().Remove(entity);

    // SaveChangesAsync يمكن استدعاؤها في الـ UnitOfWork إن وجد
}
