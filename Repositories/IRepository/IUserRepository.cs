using SKL.Models;

namespace SKL.Repositories.IRepository;

public interface IUserRepository
{
    event EventHandler? DataChangeEventHandler;

    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();

    Task<IEnumerable<Usuario>> GetSKLUsuarios();
    
    Task<IEnumerable<Login>> GetSKLCredentials();

}

