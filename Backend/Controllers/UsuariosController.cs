using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZocoAPI.Services;

namespace ZocoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuariosController : ControllerBase
{
    private readonly IUserService _userService;

    public UsuariosController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _userService.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        // Solo admin o el propio usuario puede ver su perfil
        if (userRole != "Admin" && currentUserId != id)
        {
            return Forbid();
        }

        var usuario = await _userService.GetUsuarioByIdAsync(id);
        
        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario);
    }
}
