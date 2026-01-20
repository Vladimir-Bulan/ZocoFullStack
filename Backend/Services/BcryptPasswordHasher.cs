namespace ZocoAPI.Services;

/// <summary>
/// Implementación de IPasswordHasher usando BCrypt.
/// BCrypt es un algoritmo de hash adaptativo que incluye salt automático
/// y es resistente a ataques de fuerza bruta.
/// </summary>
public class BcryptPasswordHasher : IPasswordHasher
{
    /// <summary>
    /// Genera un hash BCrypt de la contraseña.
    /// BCrypt automáticamente genera y almacena el salt en el hash.
    /// </summary>
    /// <param name="password">Contraseña en texto plano</param>
    /// <returns>Hash BCrypt (incluye salt y costo)</returns>
    public string HashPassword(string password)
    {
        // BCrypt.Net genera automáticamente un salt y lo incluye en el hash
        // El costo por defecto es 11 (2^11 iteraciones)
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Verifica una contraseña contra un hash BCrypt.
    /// BCrypt extrae automáticamente el salt del hash almacenado.
    /// </summary>
    /// <param name="password">Contraseña en texto plano a verificar</param>
    /// <param name="hashedPassword">Hash BCrypt almacenado</param>
    /// <returns>True si la contraseña es correcta</returns>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        catch
        {
            // Si el hash es inválido o hay algún error, retornar false
            return false;
        }
    }
}