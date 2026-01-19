using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZocoAPI.DTOs;
using ZocoAPI.Services;

namespace ZocoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EstudiosController : ControllerBase
{
    private readonly IEstudioService _estudioService;

    public EstudiosController(IEstudioService estudioService)
    {
        _estudioService = estudioService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var estudios = await _estudioService.GetAllEstudiosAsync();
        return Ok(estudios);
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

        var estudios = await _estudioService.GetEstudiosByUsuarioIdAsync(usuarioId);
        return Ok(estudios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var estudio = await _estudioService.GetEstudioByIdAsync(id);
        
        if (estudio == null)
        {
            return NotFound();
        }

        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != estudio.UsuarioId)
        {
            return Forbid();
        }

        return Ok(estudio);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEstudioDto createDto)
    {
        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != createDto.UsuarioId)
        {
            return Forbid();
        }

        var estudio = await _estudioService.CreateEstudioAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = estudio.Id }, estudio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateEstudioDto updateDto)
    {
        var existingEstudio = await _estudioService.GetEstudioByIdAsync(id);
        
        if (existingEstudio == null)
        {
            return NotFound();
        }

        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != existingEstudio.UsuarioId)
        {
            return Forbid();
        }

        var updated = await _estudioService.UpdateEstudioAsync(id, updateDto);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var estudio = await _estudioService.GetEstudioByIdAsync(id);
        
        if (estudio == null)
        {
            return NotFound();
        }

        var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var userRole = User.FindFirst(ClaimTypes.Role)!.Value;

        if (userRole != "Admin" && currentUserId != estudio.UsuarioId)
        {
            return Forbid();
        }

        await _estudioService.DeleteEstudioAsync(id);
        return NoContent();
    }
}
