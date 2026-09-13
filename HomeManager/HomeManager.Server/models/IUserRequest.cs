using Newtonsoft.Json;

namespace HomeManager.Server.Models;

public interface IUserRequest {
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}