namespace ZocoAPI.Models;

public class Direccion
{
    public int Id { get; set; }
    public string Calle { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
    public string CodigoPostal { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    
    // Relación
    public Usuario Usuario { get; set; } = null!;
}
