using CRMDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProcess
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client GetClientById(int id);
       void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
        List<Client> GetClientsByIndustry(string industry);
        List<Contact> GetClientContacts(int clientId);
        bool ClientExists(int clientId);
    }
}
