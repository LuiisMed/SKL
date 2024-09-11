using SKL.Models;

namespace SKL.Services.IServices;

public interface IUserServices
{
    event EventHandler? DataChangeEventHandler;

    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();

    Task<IEnumerable<Usuario>> GetSKLUsuarios();

    Task<IEnumerable<Login>> GetSKLCredentials();
}
