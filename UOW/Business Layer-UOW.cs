using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

public class PollService : IPollService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PollService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PollDTO> GetPollByIdAsync(int id)
    {
        var poll = await _unitOfWork.Polls.GetByIdAsync(id);
        return _mapper.Map<PollDTO>(poll);
    }

    public async Task<IEnumerable<PollDTO>> GetActivePollsAsync()
    {
        var activePolls = await _unitOfWork.Polls.GetPollsByStatusAsync(isActive: true);
        return _mapper.Map<IEnumerable<PollDTO>>(activePolls);
    }

    public async Task<PollDTO> AddPollAsync(PollDTO pollDTO)
    {
        var poll = _mapper.Map<Poll>(pollDTO);
        poll.CreatedAt = DateTime.UtcNow;

        await _unitOfWork.Polls.AddAsync(poll);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<PollDTO>(poll);
    }
}