using System.Collections.Generic;

public interface ITenantService
{
    IEnumerable<Tenant> GetAll();
    Tenant GetById(int id);
    void Add(Tenant tenant);
    void Update(Tenant tenant);
    void Delete(int id);
}

