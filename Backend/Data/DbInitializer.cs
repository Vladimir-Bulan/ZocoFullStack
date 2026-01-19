using ZocoAPI.Models;

namespace ZocoAPI.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // Si ya hay usuarios, no hacer nada
        if (context.Usuarios.Any())
        {
            return;
        }

        // Crear usuario Admin
        var adminPassword = BCrypt.Net.BCrypt.HashPassword("admin123");
        var admin = new Usuario
        {
            Nombre = "Administrador",
            Email = "admin@zoco.com",
            PasswordHash = adminPassword,
            Rol = "Admin",
            FechaCreacion = DateTime.UtcNow
        };

        // Crear usuario normal
        var userPassword = BCrypt.Net.BCrypt.HashPassword("user123");
        var usuario = new Usuario
        {
            Nombre = "Usuario Test",
            Email = "user@zoco.com",
            PasswordHash = userPassword,
            Rol = "Usuario",
            FechaCreacion = DateTime.UtcNow
        };

        context.Usuarios.AddRange(admin, usuario);
        context.SaveChanges();

        // Agregar datos de ejemplo para el usuario normal
        var estudio = new Estudio
        {
            Institucion = "Universidad Nacional",
            Titulo = "Ingeniería en Sistemas",
            AnioInicio = 2018,
            AnioFin = 2022,
            UsuarioId = usuario.Id
        };

        var direccion = new Direccion
        {
            Calle = "Av. Principal 123",
            Ciudad = "Buenos Aires",
            CodigoPostal = "1000",
            Pais = "Argentina",
            UsuarioId = usuario.Id
        };

        context.Estudios.Add(estudio);
        context.Direcciones.Add(direccion);
        context.SaveChanges();
    }
}
