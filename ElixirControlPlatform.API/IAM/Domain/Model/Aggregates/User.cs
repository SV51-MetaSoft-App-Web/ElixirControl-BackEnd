using System.Text.Json;
using System.Text.Json.Serialization;
using ElixirControlPlatform.API.IAM.Domain.Model.ValueObjects;

namespace ElixirControlPlatform.API.IAM.Domain.Model.Aggregates;

/// <summary>
/// Represents a user in the system. 
/// </summary>
/// <param name="username">
/// The username of the user.
/// </param>
/// <param name="passwordHash">
/// The password hash of the user.
/// </param>
public class User(string username, string passwordHash, Roles? rol)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class. 
    /// </summary>
    public User() : this(string.Empty, string.Empty,null) {}
    
    public int Id { get; }

    public string Username { get; private set; } = username;
    
   
    [JsonConverter(typeof(RolesJsonConverter))]
    public Roles? Role { get; private set; } = rol;



    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    /// <summary>
    /// Updates the username of the user. 
    /// </summary>
    /// <param name="username">
    /// The new username of the user.
    /// </param>
    /// <returns>
    /// The updated <see cref="User"/> user.
    /// </returns>
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    
    /// <summary>
    /// Updates the password hash of the user. 
    /// </summary>
    /// <param name="passwordHash">
    /// The new password hash of the user.
    /// </param>
    /// <returns>
    /// The updated <see cref="User"/> user.
    /// </returns>
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    private class RolesJsonConverter : JsonConverter<Roles?>
    {
        public override Roles? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var roleString = reader.GetString();
            if (string.IsNullOrEmpty(roleString))
            {
                return null;
            }
            return Enum.TryParse<Roles>(roleString, true, out var role) ? role : throw new JsonException($"Invalid role: {roleString}");
        }

        public override void Write(Utf8JsonWriter writer, Roles? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString());
        }
    }
}