using ElixirControlPlatform.API.CustomerManagement.Domain.Model.Commands;
using ElixirControlPlatform.API.Profiles.Domain.Model.Aggregate;

namespace ElixirControlPlatform.API.CustomerManagement.Domain.Model.Aggregates;

///Clients Aggregate
/// <summary>
/// This class represents the Clients aggregate. It is used to store the information of the clients.
/// </summary>
public class Client
{
    public int Id { get; private set; }
    
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public string PersonName { get; private set; }
    public int Dni { get; private set; }
    public string Email { get; private set; }
    public string BusinessName { get; private set; }
    public int Phone { get; private set; }
    public string Address { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public int Ruc { get; private set; }
    
    protected Client()
    {
        this.PersonName = string.Empty;
        this.Dni = int.MinValue;
        this.Email = string.Empty;
        this.BusinessName = string.Empty;
        this.Phone = int.MinValue;
        this.Address = string.Empty;
        this.Country = string.Empty;
        this.City = string.Empty;
        this.Ruc =int.MinValue;
        
    }

    /// <summary>
    /// Constructor of the Clients aggregate
    /// </summary>
    /// <remarks>
    /// This constructor is the command handle for the CreateClientsSourceCommand.
    /// </remarks>
    /// <param name="command">The CreateClientsSourceCommand</param>
    public Client(CreateClientCommand command,Guid profileId)
    {
        this.PersonName = command.PersonName;
        this.Dni = command.Dni;
        this.Email = command.Email;
        this.BusinessName = command.BusinessName;
        this.Phone = command.Phone;
        this.Address = command.Address;
        this.Country = command.Country;
        this.City = command.City;
        this.Ruc = command.Ruc;
        this.ProfileId = profileId;
    }
    
  
    
   /// <summary>
   /// Update the client by Id
   /// </summary>
   /// <param name="command">
   /// The UpdateClientByIdCommand
   /// </param>
    public void UpdateClientById(UpdateClientByIdCommand command)
    {
        
        this.PersonName = command.PersonName;
        this.Dni = command.Dni;
        this.Email = command.Email;
        this.BusinessName = command.BusinessName;
        this.Phone = command.Phone;
        this.Address = command.Address;
        this.Country = command.Country;
        this.City = command.City;
        this.Ruc = command.Ruc;
    }

}

