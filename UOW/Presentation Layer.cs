// Presentation/Controllers/PollsController.cs
[ApiController]
[Route("api/[controller]")]
public class PollsController : ControllerBase
{
    private readonly IPollService _pollService;

    public PollsController(IPollService pollService)
    {
        _pollService = pollService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPoll(int id)
    {
        var poll = await _pollService.GetPollByIdAsync(id);
        return Ok(poll);
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActivePolls()
    {
        var activePolls = await _pollService.GetActivePollsAsync();
        return Ok(activePolls);
    }
}

