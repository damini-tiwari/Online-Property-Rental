//namespace TenantManagement.Repository
//{
//    public class RentalApplicationRepository
//    {
//    }
//}

using Microsoft.EntityFrameworkCore;

namespace TenantManagement.Repository
{
    public class RentalApplicationRepository : IRentalApplicationRepository
    {
        private readonly TenantDbContext _context;

        public RentalApplicationRepository(TenantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalApplication>> GetAllApplicationsAsync()
        {
            return await _context.RentalApplications
                .Include(ra => ra.Tenant)
                                .ToListAsync();
        }

        public async Task<RentalApplication> GetApplicationByIdAsync(Guid id)
        {
            return await _context.RentalApplications
                .Include(ra => ra.Tenant)
                                .FirstOrDefaultAsync(ra => ra.ApplicationId == id);
        }

        public async Task<RentalApplication> CreateApplicationAsync(RentalApplication application)
        {
            _context.RentalApplications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<RentalApplication> UpdateApplicationAsync(long id, RentalApplication application)
        {
            var existingApplication = await _context.RentalApplications.FindAsync(id);
            if (existingApplication == null)
            {
                throw new KeyNotFoundException("Rental application not found");
            }

            existingApplication.TenantId = application.TenantId;
            existingApplication.ApplicationId = application.ApplicationId;
            existingApplication.Status = application.Status;

            await _context.SaveChangesAsync();
            return existingApplication;
        }

        public async Task DeleteApplicationAsync(long id)
        {
            var application = await _context.RentalApplications.FindAsync(id);
            if (application == null)
            {
                throw new KeyNotFoundException("Rental application not found");
            }

            _context.RentalApplications.Remove(application);
            await _context.SaveChangesAsync();
        }
    }
}
