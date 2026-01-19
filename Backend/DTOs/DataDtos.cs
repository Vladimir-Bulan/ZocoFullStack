namespace ZocoAPI.DTOs;

public class EstudioDto
{
    public int Id { get; set; }
    public string Institucion { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int AnioInicio { get; set; }
    public int? AnioFin { get; set; }
    public int UsuarioId { get; set; }
}

public class CreateEstudioDto
{
    public string Institucion { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int AnioInicio { get; set; }
    public int? AnioFin { get; set; }
    public int UsuarioId { get; set; }
}

public class DireccionDto
{
    public int Id { get; set; }
    public string Calle { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
    public string CodigoPostal { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
}

public class CreateDireccionDto
{
    public string Calle { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
    public string CodigoPostal { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
}
