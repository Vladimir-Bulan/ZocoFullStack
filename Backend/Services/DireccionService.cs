using ZocoAPI.DTOs;
using ZocoAPI.Models;
using ZocoAPI.Repositories;

namespace ZocoAPI.Services;

public interface IDireccionService
{
    Task<IEnumerable<DireccionDto>> GetAllDireccionesAsync();
    Task<IEnumerable<DireccionDto>> GetDireccionesByUsuarioIdAsync(int usuarioId);
    Task<DireccionDto?> GetDireccionByIdAsync(int id);
    Task<DireccionDto> CreateDireccionAsync(CreateDireccionDto createDto);
    Task<DireccionDto?> UpdateDireccionAsync(int id, CreateDireccionDto updateDto);
    Task<bool> DeleteDireccionAsync(int id);
}

public class DireccionService : IDireccionService
{
    private readonly IDireccionRepository _direccionRepository;

    public DireccionService(IDireccionRepository direccionRepository)
    {
        _direccionRepository = direccionRepository;
    }

    public async Task<IEnumerable<DireccionDto>> GetAllDireccionesAsync()
    {
        var direcciones = await _direccionRepository.GetAllAsync();
        return direcciones.Select(MapToDto);
    }

    public async Task<IEnumerable<DireccionDto>> GetDireccionesByUsuarioIdAsync(int usuarioId)
    {
        var direcciones = await _direccionRepository.GetByUsuarioIdAsync(usuarioId);
        return direcciones.Select(MapToDto);
    }

    public async Task<DireccionDto?> GetDireccionByIdAsync(int id)
    {
        var direccion = await _direccionRepository.GetByIdAsync(id);
        return direccion == null ? null : MapToDto(direccion);
    }

    public async Task<DireccionDto> CreateDireccionAsync(CreateDireccionDto createDto)
    {
        var direccion = new Direccion
        {
            Calle = createDto.Calle,
            Ciudad = createDto.Ciudad,
            CodigoPostal = createDto.CodigoPostal,
            Pais = createDto.Pais,
            UsuarioId = createDto.UsuarioId
        };

        var created = await _direccionRepository.CreateAsync(direccion);
        return MapToDto(created);
    }

    public async Task<DireccionDto?> UpdateDireccionAsync(int id, CreateDireccionDto updateDto)
    {
        var direccion = await _direccionRepository.GetByIdAsync(id);
        if (direccion == null) return null;

        direccion.Calle = updateDto.Calle;
        direccion.Ciudad = updateDto.Ciudad;
        direccion.CodigoPostal = updateDto.CodigoPostal;
        direccion.Pais = updateDto.Pais;

        var updated = await _direccionRepository.UpdateAsync(direccion);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteDireccionAsync(int id)
    {
        var direccion = await _direccionRepository.GetByIdAsync(id);
        if (direccion == null) return false;

        await _direccionRepository.DeleteAsync(id);
        return true;
    }

    private static DireccionDto MapToDto(Direccion direccion)
    {
        return new DireccionDto
        {
            Id = direccion.Id,
            Calle = direccion.Calle,
            Ciudad = direccion.Ciudad,
            CodigoPostal = direccion.CodigoPostal,
            Pais = direccion.Pais,
            UsuarioId = direccion.UsuarioId
        };
    }
}
