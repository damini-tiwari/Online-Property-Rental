using TenantManagement.Repository;

public class RentalApplicationService
{
    private readonly IRentalApplicationRepository _applicationRepository;

    public RentalApplicationService(IRentalApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<IEnumerable<RentalApplication>> GetAllApplicationsAsync()
    {
        return await _applicationRepository.GetAllApplicationsAsync();
    }

    public async Task<RentalApplication> GetApplicationByIdAsync(Guid id)
    {
        return await _applicationRepository.GetApplicationByIdAsync(id);
    }

    public async Task<RentalApplication> CreateApplicationAsync(RentalApplication application)
    {
        return await _applicationRepository.CreateApplicationAsync(application);
    }

    public async Task<RentalApplication> UpdateApplicationAsync(long id, RentalApplication application)
    {
        return await _applicationRepository.UpdateApplicationAsync(id, application);
    }

    public async Task DeleteApplicationAsync(long id)
    {
        await _applicationRepository.DeleteApplicationAsync(id);
    }
}
