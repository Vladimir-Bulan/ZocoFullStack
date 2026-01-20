using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZocoAPI.DTOs;
using ZocoAPI.Models;
using ZocoAPI.Repositories;

namespace ZocoAPI.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
    Task<UsuarioDto?> RegisterAsync(RegisterDto registerDto);
    Task LogoutAsync(int usuarioId);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ISessionLogRepository _sessionLogRepository;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(
    IUserRepository userRepository,
    ISessionLogRepository sessionLogRepository,
    IConfiguration configuration,
    IPasswordHasher passwordHasher) // ✅ AGREGAR PARÁMETRO
    {
        _userRepository = userRepository;
        _sessionLogRepository = sessionLogRepository;
        _configuration = configuration;
        _passwordHasher = passwordHasher; // ✅ AGREGAR ASIGNACIÓN
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto loginDto)
    {
        var usuario = await _userRepository.GetByEmailAsync(loginDto.Email);

        if (usuario == null || !_passwordHasher.VerifyPassword(loginDto.Password, usuario.PasswordHash))
        {
            return null;
        }

        // Crear sesión
        var sessionLog = new SessionLog
        {
            UsuarioId = usuario.Id,
            FechaInicio = DateTime.UtcNow
        };
        await _sessionLogRepository.CreateAsync(sessionLog);

        // Generar token
        var token = GenerateJwtToken(usuario);

        return new LoginResponseDto
        {
            Token = token,
            Usuario = new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = usuario.Rol
            }
        };
    }

    public async Task<UsuarioDto?> RegisterAsync(RegisterDto registerDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            return null;
        }

        var usuario = new Usuario
        {
            Nombre = registerDto.Nombre,
            Email = registerDto.Email,
            PasswordHash = _passwordHasher.HashPassword(registerDto.Password),
            Rol = registerDto.Rol,
            FechaCreacion = DateTime.UtcNow
        };

        var createdUser = await _userRepository.CreateAsync(usuario);

        return new UsuarioDto
        {
            Id = createdUser.Id,
            Nombre = createdUser.Nombre,
            Email = createdUser.Email,
            Rol = createdUser.Rol
        };
    }

    public async Task LogoutAsync(int usuarioId)
    {
        var activeSession = await _sessionLogRepository.GetActiveSessionAsync(usuarioId);
        if (activeSession != null)
        {
            await _sessionLogRepository.CloseSessionAsync(activeSession.Id);
        }
    }

    private string GenerateJwtToken(Usuario usuario)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Rol)
            }),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"]!)),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
