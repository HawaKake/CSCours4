using Cours.Models;

namespace Cours.Services;

public interface IDetteService{
    Task<IEnumerable<Dette>> GetDettesClientAsync(int clientId);
}
