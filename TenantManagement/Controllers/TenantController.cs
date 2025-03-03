using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TenantManagement.Models;

[ApiController]
[Route("api/[controller]")]
public class TenantController : Controller
{
    //private readonly ITenantService _tenantService;

    //public TenantController(ITenantService tenantService)
    //{
    //    _tenantService = tenantService;
    //}

    //[HttpGet]
    //public IActionResult GetAll()
    //{
    //    var tenants = _tenantService.GetAll();
    //    return Ok(tenants);
    //}

    //[HttpPost]
    //public IActionResult Register(Tenant tenant)
    //{
    //    _tenantService.Add(tenant);
    //    return CreatedAtAction(nameof(GetAll), new { id = tenant.TenantId }, tenant);
    //}

    // Other CRUD endpoints...

    private readonly UserManager<Tenant> _userManager;
    private readonly SignInManager<Tenant> _signInManager;

    public TenantController(UserManager<Tenant> userManager, SignInManager<Tenant> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new Tenant { Username = model.Username, Email = model.Email, Tenant_name = model.Tenant_name };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok(new { Message = "User registered successfully" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

       if(result.Succeeded)
        {
            return Ok(new { Message = "Login successful" });
        }

        return Unauthorized();
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }
        var model = new Tenant
        {
            Email = user.Email,
            Tenant_name = user.Tenant_name
            // Map other tenant-specific properties
        };
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Profile(Tenant model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }
        user.Tenant_name = model.Tenant_name;
        // Update other tenant-specific properties

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return RedirectToAction("Profile");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(model);
    }
}

