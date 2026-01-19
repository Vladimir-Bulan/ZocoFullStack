using Microsoft.EntityFrameworkCore;
using ZocoAPI.Data;
using ZocoAPI.Models;

namespace ZocoAPI.Repositories;

public interface IDireccionRepository
{
    Task<Direccion?> GetByIdAsync(int id);
    Task<IEnumerable<Direccion>> GetByUsuarioIdAsync(int usuarioId);
    Task<IEnumerable<Direccion>> GetAllAsync();
    Task<Direccion> CreateAsync(Direccion direccion);
    Task<Direccion> UpdateAsync(Direccion direccion);
    Task DeleteAsync(int id);
}

public class DireccionRepository : IDireccionRepository
{
    private readonly ApplicationDbContext _context;

    public DireccionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Direccion?> GetByIdAsync(int id)
    {
        return await _context.Direcciones
            .Include(d => d.Usuario)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<Direccion>> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _context.Direcciones
            .Where(d => d.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Direccion>> GetAllAsync()
    {
        return await _context.Direcciones
            .Include(d => d.Usuario)
            .ToListAsync();
    }

    public async Task<Direccion> CreateAsync(Direccion direccion)
    {
        _context.Direcciones.Add(direccion);
        await _context.SaveChangesAsync();
        return direccion;
    }

    public async Task<Direccion> UpdateAsync(Direccion direccion)
    {
        _context.Direcciones.Update(direccion);
        await _context.SaveChangesAsync();
        return direccion;
    }

    public async Task DeleteAsync(int id)
    {
        var direccion = await _context.Direcciones.FindAsync(id);
        if (direccion != null)
        {
            _context.Direcciones.Remove(direccion);
            await _context.SaveChangesAsync();
        }
    }
}
