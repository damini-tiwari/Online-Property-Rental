using System.Collections.Generic;
using System.Linq;

public class TenantRepository : ITenantRepository
{
    private readonly TenantDbContext _context;

    public TenantRepository(TenantDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Tenant> GetAll()
    {
        return _context.Tenants.ToList();
    }

    public Tenant GetById(int id)
    {
        return _context.Tenants.Find(id);
    }

    public void Add(Tenant tenant)
    {
        _context.Tenants.Add(tenant);
        _context.SaveChanges();
    }

    public void Update(Tenant tenant)
    {
        _context.Tenants.Update(tenant);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var tenant = _context.Tenants.Find(id);
        if (tenant != null)
        {
            _context.Tenants.Remove(tenant);
            _context.SaveChanges();
        }
    }
}

