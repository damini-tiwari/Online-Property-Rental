using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RentalApplicationsController : ControllerBase
{
    private readonly RentalApplicationService _applicationService;

    public RentalApplicationsController(RentalApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentalApplication>>> GetAllApplications()
    {
        var applications = await _applicationService.GetAllApplicationsAsync();
        return Ok(applications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RentalApplication>> GetApplicationById(Guid id)
    {
        var application = await _applicationService.GetApplicationByIdAsync(id);
        if (application == null)
        {
            return NotFound();
        }
        return Ok(application);
    }

    [HttpPost]
    public async Task<ActionResult<RentalApplication>> CreateApplication(RentalApplication application)
    {
        var createdApplication = await _applicationService.CreateApplicationAsync(application);
        return CreatedAtAction(nameof(GetApplicationById), new { id = createdApplication.ApplicationId }, createdApplication);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApplication(long id, RentalApplication application)
    {
        try
        {
            var updatedApplication = await _applicationService.UpdateApplicationAsync(id, application);
            return Ok(updatedApplication);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(long id)
    {
        try
        {
            await _applicationService.DeleteApplicationAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
