// Data/UnitOfWork/UnitOfWork.cs
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private bool _disposed = false;

    public IPollRepository PollRepository { get; }
    public IRepository<Option> OptionRepository { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        PollRepository = new PollRepository(context);
        OptionRepository = new Repository<Option>(context);
    }

    public async Task<int> SaveChangesAsync() 
        => await _context.SaveChangesAsync();

    public void Dispose() => Dispose(true);
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
            _context.Dispose();
        _disposed = true;
    }
}
