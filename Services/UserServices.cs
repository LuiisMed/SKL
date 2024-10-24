using SKL.Models;
using SKL.Repositories.IRepository;
using SKL.Services.IServices;
using System.Xml.Linq;

namespace SKL.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _repository;
    public event EventHandler? DataChangeEventHandler;

    public UserServices(IUserRepository repository)
    {

        _repository = repository; 
    
    }

    public async Task<IEnumerable<Usuario>> GetSKLUsuarios()
            => await _repository.GetSKLUsuarios();

    public async Task<Usuario> GetSKLUsuarioAsync(int idusr)
    => await _repository.GetSKLUsuarioAsync(idusr);

    public async Task<IEnumerable<Usuario>> GetSKLUserEmailAsync(int idusr)
    => await _repository.GetSKLUserEmailAsync(idusr);

    public async Task<IEnumerable<Login>> GetSKLCredentials()
    => await _repository.GetSKLCredentials();

    public async Task<(bool, string)> InsertSKLUsuariosAsync(Usuario data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLUsuariosAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLUsuariosAsync(Usuario data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLUsuariosAsync(data);
    }
    
    public async Task<(bool, string)> DeleteSKLUsuariosAsync(int idusr)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLUsuariosAsync(idusr);
    }

    //public async Task<(bool, string)> SaveSKLUsuariosAsync(Usuario usuario)
    //{
    //    _repository.DataChangeEventHandler += DataChangeEventHandler;
    //    Func<Usuario, Task<(bool, string)>> method = usuario.IdUser == 0
    //        ? _repository.InsertSKLUsuariosAsync
    //        : _repository.UpdateSKLUsuariosAsync;
    //    return await method.Invoke(usuario);
    //}

}
