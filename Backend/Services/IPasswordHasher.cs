namespace ZocoAPI.Services;

/// <summary>
/// Interfaz para el servicio de hash de contraseñas.
/// Permite desacoplar la lógica de negocio de la implementación específica de hash.
/// Principio SOLID: Dependency Inversion Principle (DIP)
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Genera un hash seguro de la contraseña proporcionada.
    /// </summary>
    /// <param name="password">Contraseña en texto plano</param>
    /// <returns>Hash de la contraseña</returns>
    string HashPassword(string password);

    /// <summary>
    /// Verifica si una contraseña en texto plano coincide con un hash.
    /// </summary>
    /// <param name="password">Contraseña en texto plano a verificar</param>
    /// <param name="hashedPassword">Hash almacenado para comparar</param>
    /// <returns>True si la contraseña es válida, False en caso contrario</returns>
    bool VerifyPassword(string password, string hashedPassword);
}