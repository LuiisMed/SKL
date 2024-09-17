using SKL.Models;
using System.Xml.Linq;

namespace SKL.Services.IServices;

public interface IUserServices
{
    event EventHandler? DataChangeEventHandler;

    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();
    Task<IEnumerable<Usuario>> GetSKLUsuarios();
    Task<Usuario> GetSKLUsuarioAsync(int idusr);
    Task<IEnumerable<Login>> GetSKLCredentials();
    Task<(bool, string)> SaveSKLUsuariosAsync(Usuario usuario);
    Task<(bool, string)> InsertSKLUsuariosAsync(Usuario data);

    Task<(bool, string)> DeleteSKLUsuariosAsync(int idusr);
}
