using Microsoft.EntityFrameworkCore;
using ZocoAPI.Data;
using ZocoAPI.Models;

namespace ZocoAPI.Repositories;

public interface IEstudioRepository
{
    Task<Estudio?> GetByIdAsync(int id);
    Task<IEnumerable<Estudio>> GetByUsuarioIdAsync(int usuarioId);
    Task<IEnumerable<Estudio>> GetAllAsync();
    Task<Estudio> CreateAsync(Estudio estudio);
    Task<Estudio> UpdateAsync(Estudio estudio);
    Task DeleteAsync(int id);
}

public class EstudioRepository : IEstudioRepository
{
    private readonly ApplicationDbContext _context;

    public EstudioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Estudio?> GetByIdAsync(int id)
    {
        return await _context.Estudios
            .Include(e => e.Usuario)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Estudio>> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _context.Estudios
            .Where(e => e.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Estudio>> GetAllAsync()
    {
        return await _context.Estudios
            .Include(e => e.Usuario)
            .ToListAsync();
    }

    public async Task<Estudio> CreateAsync(Estudio estudio)
    {
        _context.Estudios.Add(estudio);
        await _context.SaveChangesAsync();
        return estudio;
    }

    public async Task<Estudio> UpdateAsync(Estudio estudio)
    {
        _context.Estudios.Update(estudio);
        await _context.SaveChangesAsync();
        return estudio;
    }

    public async Task DeleteAsync(int id)
    {
        var estudio = await _context.Estudios.FindAsync(id);
        if (estudio != null)
        {
            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();
        }
    }
}
