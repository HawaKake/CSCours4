using Cours.Data;
using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Services.Impl;

public class PaiementService : IPaiementService
{
    private readonly ApplicationDbContext _context;

    public PaiementService(ApplicationDbContext context)
    {
        this._context = context;
    }
  
    public async Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId)
    {
        return await _context.Paiements.Where(paiement => paiement.DetteId == detteId).ToListAsync();
    }
}
