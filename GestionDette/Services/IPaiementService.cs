using Cours.Models;

namespace Cours.Services;

public interface IPaiementService{
    Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId);
}
