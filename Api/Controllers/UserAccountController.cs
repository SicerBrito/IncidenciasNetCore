using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UserAccountController: ApiBaseController{
    private readonly IUserServiceInterface _UserServices;
    public UserAccountController(IUserServiceInterface userServices) => _UserServices = userServices;

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterDto model) => Ok(await _UserServices.RegisterAsync(model));

    [HttpPost("Token")]    
    public async Task<ActionResult> GetTokenAsync(LoginDto model) => Ok(await _UserServices.GetTokenAsync(model));

    [HttpPost("addrol")]
    public async Task<ActionResult> AddRolAsync(AddRoleDto model) => Ok(await _UserServices.AddRoleAsync(model));
    
}