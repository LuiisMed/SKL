using SKL.Models;

namespace SKL.Services.IServices;

public interface ISKLServices
{
    event EventHandler? DataChangeEventHandler;


    /*--------------------------------DEPARTMENTS----------------------------------*/
    Task<IEnumerable<Department>> GetSKLDepartmentsAsync();
    Task<Department> GetSKLDepartmentAsync(int idDepartment);
    Task<(bool, string)> InsertSKLDepartmentsAsync(Department data);
    Task<(bool, string)> UpdateSKLDepartmentsAsync(Department data);
    Task<(bool, string)> DeleteSKLDepartmentsAsync(int idDepartment);
    /*---------------------------------------------------------------------------*/
    /*-----------------------------------USERTYPE-----------------------------------*/
    Task<IEnumerable<UserType>> GetSKLUserTypesAsync();
    Task<UserType> GetSKLUsertypeAsync(int idUsertype);
    Task<(bool, string)> InsertSKLUsertypesAsync(UserType data);
    Task<(bool, string)> UpdateSKLUsertypesAsync(UserType data);
    Task<(bool, string)> DeleteSKLUsertypesAsync(int idUsertype);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------SHIFT-------------------------------------*/
    Task<IEnumerable<Shift>> GetSKLShiftsAsync();
    Task<Shift> GetSKLShiftAsync(int idShift);
    Task<(bool, string)> InsertSKLShiftsAsync(Shift data);
    Task<(bool, string)> UpdateSKLShiftsAsync(Shift data);
    Task<(bool, string)> DeleteSKLShiftsAsync(int idShift);
    /*---------------------------------------------------------------------------*/
    /*----------------------------------POSITION------------------------------------*/
    Task<IEnumerable<Position>> GetSKLPositionsAsync();
    Task<Position> GetSKLPositionAsync(int idPosition);
    Task<(bool, string)> InsertSKLPositionAsync(Position data);
    Task<(bool, string)> UpdateSKLPositionAsync(Position data);
    Task<(bool, string)> DeleteSKLPositionAsync(int idPosition);
    /*---------------------------------------------------------------------------*/
    /*----------------------------------ASPECTS------------------------------------*/
    Task<IEnumerable<Aspect>> GetSKLAspectsAsync();
    Task<Aspect> GetSKLAspectAsync(int idAspect);
    Task<(bool, string)> InsertSKLAspectAsync(Aspect data);
    Task<(bool, string)> UpdateSKLAspectAsync(Aspect data);
    Task<(bool, string)> DeleteSKLAspectAsync(int idAspect);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------FASE--------------------------------------*/
    Task<IEnumerable<Fase>> GetSKLFasesAsync();
    Task<Fase> GetSKLFaseAsync(int idFase);
    Task<(bool, string)> InsertSKLFaseAsync(Fase data);
    Task<(bool, string)> UpdateSKLFaseAsync(Fase data);
    Task<(bool, string)> DeleteSKLFaseAsync(int idFase);



}

