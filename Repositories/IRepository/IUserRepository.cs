using SKL.Models;

namespace SKL.Repositories.IRepository;

public interface IUserRepository
{
    event EventHandler? DataChangeEventHandler;

    Task<IEnumerable<Usuario>> GetSKLUsuarios();
    Task<Usuario> GetSKLUsuarioAsync(int idusr);
    Task<IEnumerable<Usuario>> GetSKLUserEmailAsync(int idusr);
    Task<IEnumerable<Login>> GetSKLCredentials();
    Task<(bool, string)> InsertSKLUsuariosAsync(Usuario usuario);
    Task<(bool, string)> UpdateSKLUsuariosAsync(Usuario usuario);
    Task<(bool, string)> DeleteSKLUsuariosAsync(int idusr);

}

