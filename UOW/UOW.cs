// Domain/Interfaces/IUnitOfWork.cs
public interface IUnitOfWork : IDisposable
{
    // الـ Repositories هنا
    IPollRepository PollRepository { get; }
    IRepository<Option> OptionRepository { get; } 

    Task<int> SaveChangesAsync();
}
