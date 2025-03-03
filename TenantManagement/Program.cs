using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TenantManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TenantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Tenant, IdentityRole>()
        .AddEntityFrameworkStores<TenantDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<IRentalApplicationRepository,RentalApplicationRepository>();
builder.Services.AddScoped<ITenantRepository,TenantRepository>();
builder.Services.AddScoped<ITenantService,TenantService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    services.Configure<IdentityOptions>(options =>
    {
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    });

    services.AddIdentity<Tenant, IdentityRole>()
            .AddEntityFrameworkStores<TenantDbContext>()
            .AddDefaultTokenProviders();
}

//void ConfigureServices()
//{
//builder.Services.AddDbContext<TenantDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


    //app.MapControllers();

    app.Run();
//}




