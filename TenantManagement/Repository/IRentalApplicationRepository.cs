namespace TenantManagement.Repository
{
    public interface IRentalApplicationRepository
    {
        Task<IEnumerable<RentalApplication>> GetAllApplicationsAsync();
        Task<RentalApplication> GetApplicationByIdAsync(Guid id);
        Task<RentalApplication> CreateApplicationAsync(RentalApplication application);
        Task<RentalApplication> UpdateApplicationAsync(long id, RentalApplication application);
        Task DeleteApplicationAsync(long id);
    }
}
