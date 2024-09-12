using SKL.Models;
using SKL.Repositories.IRepository;
using SKL.Services.IServices;

namespace SKL.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _repository;
    public event EventHandler? DataChangeEventHandler;

    public UserServices(IUserRepository repository)
    {

        _repository = repository; 
    
    }

    public async Task<IEnumerable<Department>> GetSKLDepartmentsAsync()
    => await _repository.GetSKLDepartmentsAsync();

    public async Task<IEnumerable<Usuario>> GetSKLUsuarios()
            => await _repository.GetSKLUsuarios();

    public async Task<IEnumerable<Login>> GetSKLCredentials()
    => await _repository.GetSKLCredentials();

    public async Task<(bool, string)> SaveSKLUsuariosAsync(Usuario usuario)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        Func<Usuario, Task<(bool, string)>> method = usuario.IdUser == 0
            ? _repository.InsertSKLUsuariosAsync
            : _repository.UpdateSKLUsuariosAsync;
        return await method.Invoke(usuario);
    }

    public async Task<(bool, string)> DeleteSKLUsuariosAsync(int usuarioId)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLUsuariosAsync(usuarioId);
    }

}
