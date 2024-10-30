using ClientsProcess;
using CRMDataModel.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // GET: api/Clients
    [HttpGet]
    public IActionResult GetAllClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }

    // GET: api/Clients/{id}
    [HttpGet("{id}")]
    public IActionResult GetClientById(int id)
    {
        var client = _clientService.GetClientById(id);
        if (client == null)
        {
            return NotFound("Klienti nuk u gjet.");
        }
        return Ok(client);
    }

    // POST: api/Clients
    [HttpPost]
    public IActionResult AddClient([FromBody] Client client)
    {
        if (client == null)
        {
            return BadRequest("Të dhënat e klientit janë të pavlefshme.");
        }

        _clientService.AddClient(client);
        return CreatedAtAction(nameof(GetClientById), new { id = client.ClientId }, client);
    }

    // PUT: api/Clients/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateClient(int id, [FromBody] Client client)
    {
        if (client == null || client.ClientId != id)
        {
            return BadRequest("Të dhënat e klientit janë të pavlefshme.");
        }

        var existingClient = _clientService.GetClientById(id);
        if (existingClient == null)
        {
            return NotFound("Klienti nuk u gjet.");
        }

        _clientService.UpdateClient(client);
        return NoContent();
    }

    // DELETE: api/Clients/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        var existingClient = _clientService.GetClientById(id);
        if (existingClient == null)
        {
            return NotFound("Klienti nuk u gjet.");
        }

        _clientService.DeleteClient(id);
        return NoContent();
    }
}
