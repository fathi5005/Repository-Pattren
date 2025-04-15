// Domain/Interfaces/IPollRepository.cs
public interface IPollRepository : IRepository<Poll>
{
    Task<IEnumerable<Poll>> GetPollsByStatusAsync(bool isActive);
}

// Data/Repositories/PollRepository.cs
public class PollRepository : Repository<Poll>, IPollRepository
{
    public PollRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Poll>> GetPollsByStatusAsync(bool isActive)
    {
        return await _context.Polls
            .Where(p => p.IsActive == isActive)
            .ToListAsync();
    }
}
