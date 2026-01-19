using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZocoAPI.DTOs;
using ZocoAPI.Services;

namespace ZocoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DireccionesController : ControllerBase
{
    private readonly IDireccionService _direccionService;

    public DireccionesController(IDireccionService direccionService)
    {
        _direccionService = direccionService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var direcciones = await _direccionService.GetAllDireccionesAsync();
        return Ok(direcciones);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> GetByUsuarioId(int usuarioId)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != usuarioId)
        {
            return Forbid();
        }

        var direcciones = await _direccionService.GetDireccionesByUsuarioIdAsync(usuarioId);
        return Ok(direcciones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var direccion = await _direccionService.GetDireccionByIdAsync(id);
        
        if (direccion == null)
        {
            return NotFound();
        }

        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != direccion.UsuarioId)
        {
            return Forbid();
        }

        return Ok(direccion);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDireccionDto createDto)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != createDto.UsuarioId)
        {
            return Forbid();
        }

        var direccion = await _direccionService.CreateDireccionAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = direccion.Id }, direccion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateDireccionDto updateDto)
    {
        var existingDireccion = await _direccionService.GetDireccionByIdAsync(id);
        
        if (existingDireccion == null)
        {
            return NotFound();
        }

        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != existingDireccion.UsuarioId)
        {
            return Forbid();
        }

        var updated = await _direccionService.UpdateDireccionAsync(id, updateDto);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var direccion = await _direccionService.GetDireccionByIdAsync(id);
        
        if (direccion == null)
        {
            return NotFound();
        }

        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != direccion.UsuarioId)
        {
            return Forbid();
        }

        await _direccionService.DeleteDireccionAsync(id);
        return NoContent();
    }
}
