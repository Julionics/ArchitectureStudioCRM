using ClientsProcess;
using CRMDataModel;
using CRMDataModel.Models;

public class ClientService : IClientService
{
    private readonly CRMContext _context;

    public ClientService(CRMContext context)
    {
        _context = context;
    }

    public List<Client> GetAllClients()
    {
        return _context.Clients.ToList();
    }


    public Client GetClientById(int id)
    {
        return _context.Clients.Where(c => c.ClientId == id).FirstOrDefault();
    }

    public void AddClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public void UpdateClient(Client client)
    {
        // Gjej klientin ekzistues në bazë të ID-së
        var existingClient = _context.Clients
                                     .Where(c => c.ClientId == client.ClientId)
                                     .FirstOrDefault();

        if (existingClient != null)
        {
            // Bëj mapping të fushave manualisht
            existingClient.CompanyName = client.CompanyName;
            existingClient.Address = client.Address;
            existingClient.PhoneNumber = client.PhoneNumber;
            existingClient.Email = client.Email;
            existingClient.Industry = client.Industry;

            // Ruaj ndryshimet
            _context.SaveChanges();
        }
        else
        {
            // Opsionale: Hedh një përjashtim ose kthe një mesazh që klienti nuk u gjet
            throw new InvalidOperationException("Klienti nuk u gjet në bazën e të dhënave.");
        }
    }


    public void DeleteClient(int id)
    {
        var client = _context.Clients.Find(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }

    public List<Client> GetClientsByIndustry(string industry)
    {
        return _context.Clients.Where(c => c.Industry == industry).ToList();

    }

    public List<Contact> GetClientContacts(int clientId)
    {
        return _context.Contacts.Where(c => c.ClientId == clientId).ToList();
    }

    public bool ClientExists(int clientId)
    {
        return _context.Clients.Any(c => c.ClientId == clientId);
    }
}