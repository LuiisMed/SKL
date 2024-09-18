using SKL.Models;

namespace SKL.Services.IServices;

public interface ISKLServices
{
    event EventHandler? DataChangeEventHandler;

    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();
    Task<IEnumerable<UserType>> GetSKLUserTypeAsync();
    Task<IEnumerable<Shift>> GetSKLShiftsAsync();
    Task<IEnumerable<Position>> GetSKLPositionAsync();



}

