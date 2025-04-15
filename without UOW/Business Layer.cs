// Application/Interfaces/IPollService.cs
public interface IPollService
{
    Task<PollDTO> GetPollByIdAsync(int id);
    Task<IEnumerable<PollDTO>> GetActivePollsAsync();
}

// Application/Services/PollService.cs
public class PollService : IPollService
{
    private readonly IPollRepository _pollRepository;
    private readonly IMapper _mapper;

    public PollService(IPollRepository pollRepository, IMapper mapper)
    {
        _pollRepository = pollRepository;
        _mapper = mapper;
    }

    public async Task<PollDTO> GetPollByIdAsync(int id)
    {
        var poll = await _pollRepository.GetByIdAsync(id);
        return _mapper.Map<PollDTO>(poll);
    }

    public async Task<IEnumerable<PollDTO>> GetActivePollsAsync()
    {
        var activePolls = await _pollRepository.GetPollsByStatusAsync(isActive: true);
        return _mapper.Map<IEnumerable<PollDTO>>(activePolls);
    }

     public async Task<PollDTO> AddPollAsync(PollDTO pollDTO)
    {
        
        var poll = _mapper.Map<Poll>(pollDTO);
        poll.CreatedAt = DateTime.UtcNow; 

      
        await _pollRepository.AddAsync(poll);
        
      
        return _mapper.Map<PollDTO>(poll);
    }
}
