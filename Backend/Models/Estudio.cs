namespace ZocoAPI.Models;

public class Estudio
{
    public int Id { get; set; }
    public string Institucion { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int AnioInicio { get; set; }
    public int? AnioFin { get; set; }
    public int UsuarioId { get; set; }
    
    // Relación
    public Usuario Usuario { get; set; } = null!;
}
