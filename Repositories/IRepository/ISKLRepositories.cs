using SKL.Models;

namespace SKL.Repositories.IRepository;

public interface ISKLRepositories
{

    event EventHandler? DataChangeEventHandler;

    /*--------------------------------DEPARTMENTS----------------------------------*/
    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();
    Task<Department> GetSKLDepartmentAsync(int idDepartment);
    Task<(bool, string)> InsertSKLDepartmentsAsync(Department department);
    Task<(bool, string)> UpdateSKLDepartmentsAsync(Department department);
    Task<(bool, string)> DeleteSKLDepartmentsAsync(int idDepartment);
    /*---------------------------------------------------------------------------*/
    /*-----------------------------------USERTYPE-----------------------------------*/
    Task<IEnumerable<UserType>> GetSKLUserTypesAsync();
    Task<UserType> GetSKLUsertypeAsync(int idUsertype);
    Task<(bool, string)> InsertSKLUsertypesAsync(UserType userType);
    Task<(bool, string)> UpdateSKLUsertypesAsync(UserType userType);
    Task<(bool, string)> DeleteSKLUsertypesAsync(int idUsertype);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------SHIFT-------------------------------------*/
    Task<IEnumerable<Shift>> GetSKLShiftsAsync();
    Task<Shift> GetSKLShiftAsync(int idShift);
    Task<(bool, string)> InsertSKLShiftsAsync(Shift shift);
    Task<(bool, string)> UpdateSKLShiftsAsync(Shift shift);
    Task<(bool, string)> DeleteSKLShiftsAsync(int idShift);
    /*---------------------------------------------------------------------------*/
    /*----------------------------------POSITION------------------------------------*/
    Task<IEnumerable<Position>> GetSKLPositionsAsync();
    Task<Position> GetSKLPositionAsync(int idPosition);
    Task<(bool, string)> InsertSKLPositionAsync(Position position);
    Task<(bool, string)> UpdateSKLPositionAsync(Position position);
    Task<(bool, string)> DeleteSKLPositionAsync(int idPosition);


}
