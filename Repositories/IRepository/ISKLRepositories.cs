using SKL.Models;

namespace SKL.Repositories.IRepository;

public interface ISKLRepositories
{

    event EventHandler? DataChangeEventHandler;


    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();
    Task<IEnumerable<UserType>> GetSKLUserTypeAsync();
    Task<IEnumerable<Shift>> GetSKLShiftsAsync();
    Task<IEnumerable<Position>> GetSKLPositionAsync();

}
