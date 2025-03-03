using System.Collections.Generic;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;

    public TenantService(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
    }

    public IEnumerable<Tenant> GetAll()
    {
        return _tenantRepository.GetAll();
    }

    public Tenant GetById(int id)
    {
        return _tenantRepository.GetById(id);
    }

    public void Add(Tenant tenant)
    {
        _tenantRepository.Add(tenant);
    }

    public void Update(Tenant tenant)
    {
        _tenantRepository.Update(tenant);
    }

    public void Delete(int id)
    {
        _tenantRepository.Delete(id);
    }
}

