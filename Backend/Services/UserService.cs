using ZocoAPI.DTOs;
using ZocoAPI.Repositories;

namespace ZocoAPI.Services;

public interface IUserService
{
    Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
    Task<UsuarioDto?> GetUsuarioByIdAsync(int id);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
    {
        var usuarios = await _userRepository.GetAllAsync();
        return usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Email = u.Email,
            Rol = u.Rol
        });
    }

    public async Task<UsuarioDto?> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _userRepository.GetByIdAsync(id);
        if (usuario == null) return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Rol = usuario.Rol
        };
    }
}
