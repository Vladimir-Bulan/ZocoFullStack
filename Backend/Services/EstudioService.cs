using ZocoAPI.DTOs;
using ZocoAPI.Models;
using ZocoAPI.Repositories;

namespace ZocoAPI.Services;

public interface IEstudioService
{
    Task<IEnumerable<EstudioDto>> GetAllEstudiosAsync();
    Task<IEnumerable<EstudioDto>> GetEstudiosByUsuarioIdAsync(int usuarioId);
    Task<EstudioDto?> GetEstudioByIdAsync(int id);
    Task<EstudioDto> CreateEstudioAsync(CreateEstudioDto createDto);
    Task<EstudioDto?> UpdateEstudioAsync(int id, CreateEstudioDto updateDto);
    Task<bool> DeleteEstudioAsync(int id);
}

public class EstudioService : IEstudioService
{
    private readonly IEstudioRepository _estudioRepository;

    public EstudioService(IEstudioRepository estudioRepository)
    {
        _estudioRepository = estudioRepository;
    }

    public async Task<IEnumerable<EstudioDto>> GetAllEstudiosAsync()
    {
        var estudios = await _estudioRepository.GetAllAsync();
        return estudios.Select(MapToDto);
    }

    public async Task<IEnumerable<EstudioDto>> GetEstudiosByUsuarioIdAsync(int usuarioId)
    {
        var estudios = await _estudioRepository.GetByUsuarioIdAsync(usuarioId);
        return estudios.Select(MapToDto);
    }

    public async Task<EstudioDto?> GetEstudioByIdAsync(int id)
    {
        var estudio = await _estudioRepository.GetByIdAsync(id);
        return estudio == null ? null : MapToDto(estudio);
    }

    public async Task<EstudioDto> CreateEstudioAsync(CreateEstudioDto createDto)
    {
        var estudio = new Estudio
        {
            Institucion = createDto.Institucion,
            Titulo = createDto.Titulo,
            AnioInicio = createDto.AnioInicio,
            AnioFin = createDto.AnioFin,
            UsuarioId = createDto.UsuarioId
        };

        var created = await _estudioRepository.CreateAsync(estudio);
        return MapToDto(created);
    }

    public async Task<EstudioDto?> UpdateEstudioAsync(int id, CreateEstudioDto updateDto)
    {
        var estudio = await _estudioRepository.GetByIdAsync(id);
        if (estudio == null) return null;

        estudio.Institucion = updateDto.Institucion;
        estudio.Titulo = updateDto.Titulo;
        estudio.AnioInicio = updateDto.AnioInicio;
        estudio.AnioFin = updateDto.AnioFin;

        var updated = await _estudioRepository.UpdateAsync(estudio);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteEstudioAsync(int id)
    {
        var estudio = await _estudioRepository.GetByIdAsync(id);
        if (estudio == null) return false;

        await _estudioRepository.DeleteAsync(id);
        return true;
    }

    private static EstudioDto MapToDto(Estudio estudio)
    {
        return new EstudioDto
        {
            Id = estudio.Id,
            Institucion = estudio.Institucion,
            Titulo = estudio.Titulo,
            AnioInicio = estudio.AnioInicio,
            AnioFin = estudio.AnioFin,
            UsuarioId = estudio.UsuarioId
        };
    }
}
