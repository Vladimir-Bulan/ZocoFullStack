namespace ZocoAPI.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Rol { get; set; } = "Usuario"; // "Admin" o "Usuario"
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    
    // Relaciones
    public ICollection<Estudio> Estudios { get; set; } = new List<Estudio>();
    public ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    public ICollection<SessionLog> SessionLogs { get; set; } = new List<SessionLog>();
}
