using Microsoft.EntityFrameworkCore;
using ZocoAPI.Data;
using ZocoAPI.Models;

namespace ZocoAPI.Repositories;

public interface ISessionLogRepository
{
    Task<SessionLog> CreateAsync(SessionLog sessionLog);
    Task<SessionLog?> GetActiveSessionAsync(int usuarioId);
    Task CloseSessionAsync(int sessionLogId);
}

public class SessionLogRepository : ISessionLogRepository
{
    private readonly ApplicationDbContext _context;

    public SessionLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SessionLog> CreateAsync(SessionLog sessionLog)
    {
        _context.SessionLogs.Add(sessionLog);
        await _context.SaveChangesAsync();
        return sessionLog;
    }

    public async Task<SessionLog?> GetActiveSessionAsync(int usuarioId)
    {
        return await _context.SessionLogs
            .Where(s => s.UsuarioId == usuarioId && s.FechaFin == null)
            .OrderByDescending(s => s.FechaInicio)
            .FirstOrDefaultAsync();
    }

    public async Task CloseSessionAsync(int sessionLogId)
    {
        var session = await _context.SessionLogs.FindAsync(sessionLogId);
        if (session != null)
        {
            session.FechaFin = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
