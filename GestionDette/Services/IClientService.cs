using Cours.Models;

namespace Cours.Services;

public interface IClientService{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> Create(Client client);
}
