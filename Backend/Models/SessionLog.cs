namespace ZocoAPI.Models;

public class SessionLog
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
    public DateTime? FechaFin { get; set; }
    
    // Relación
    public Usuario Usuario { get; set; } = null!;
}
