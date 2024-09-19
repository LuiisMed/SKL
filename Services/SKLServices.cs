using SKL.Repositories.IRepository;
using SKL.Services.IServices;
using SKL.Models;
using System.Xml.Linq;

namespace SKL.Services;

public class SKLServices : ISKLServices
{

    private readonly ISKLRepositories _repository;
    public event EventHandler? DataChangeEventHandler;

    public SKLServices(ISKLRepositories repository)
    {

        _repository = repository;

    }

    /*--------------------------------DEPARTMENTS----------------------------------*/
    public async Task<IEnumerable<Department>> GetSKLDepartmentsAsync()
    => await _repository.GetSKLDepartmentsAsync();

    public async Task<Department> GetSKLDepartmentAsync(int idDepartment)
    => await _repository.GetSKLDepartmentAsync(idDepartment);

    public async Task<(bool, string)> InsertSKLDepartmentsAsync(Department data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLDepartmentsAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLDepartmentsAsync(Department data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLDepartmentsAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLDepartmentsAsync(int idDepartment)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLDepartmentsAsync(idDepartment);
    }
    /*---------------------------------------------------------------------------*/
    /*-----------------------------------USERTYPE-----------------------------------*/

    public async Task<IEnumerable<UserType>> GetSKLUserTypesAsync()
    => await _repository.GetSKLUserTypesAsync();

    public async Task<UserType> GetSKLUsertypeAsync(int idUsertype)
    => await _repository.GetSKLUsertypeAsync(idUsertype);

    public async Task<(bool, string)> InsertSKLUsertypesAsync(UserType data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLUsertypesAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLUsertypesAsync(UserType data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLUsertypesAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLUsertypesAsync(int idUsertype)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLUsertypesAsync(idUsertype);
    }
    /*---------------------------------------------------------------------------*/
    /*------------------------------------SHIFT-------------------------------------*/
    public async Task<IEnumerable<Shift>> GetSKLShiftsAsync()
    => await _repository.GetSKLShiftsAsync();

    public async Task<Shift> GetSKLShiftAsync(int idShift)
    => await _repository.GetSKLShiftAsync(idShift);

    public async Task<(bool, string)> InsertSKLShiftsAsync(Shift data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLShiftsAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLShiftsAsync(Shift data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLShiftsAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLShiftsAsync(int idShift)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLShiftsAsync(idShift);
    }
    /*---------------------------------------------------------------------------*/
    /*----------------------------------POSITION------------------------------------*/
    public async Task<IEnumerable<Position>> GetSKLPositionsAsync()
    => await _repository.GetSKLPositionsAsync();

    public async Task<Position> GetSKLPositionAsync(int idPosition)
    => await _repository.GetSKLPositionAsync(idPosition);

    public async Task<(bool, string)> InsertSKLPositionAsync(Position data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLPositionAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLPositionAsync(Position data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLPositionAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLPositionAsync(int idPosition)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLPositionAsync(idPosition);
    }
    /*---------------------------------------------------------------------------*/
    /*----------------------------------ASPECTS------------------------------------*/
    public async Task<IEnumerable<Aspect>> GetSKLAspectsAsync()
    => await _repository.GetSKLAspectsAsync();

    public async Task<Aspect> GetSKLAspectAsync(int idAspect)
    => await _repository.GetSKLAspectAsync(idAspect);

    public async Task<(bool, string)> InsertSKLAspectAsync(Aspect data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLAspectAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLAspectAsync(Aspect data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLAspectAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLAspectAsync(int idAspect)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLAspectAsync(idAspect);
    }
    /*---------------------------------------------------------------------------*/
    /*------------------------------------FASE--------------------------------------*/
    public async Task<IEnumerable<Fase>> GetSKLFasesAsync()
    => await _repository.GetSKLFasesAsync();

    public async Task<Fase> GetSKLFaseAsync(int idFase)
    => await _repository.GetSKLFaseAsync(idFase);

    public async Task<(bool, string)> InsertSKLFaseAsync(Fase data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLFaseAsync(data);
    }

    public async Task<(bool, string)> UpdateSKLFaseAsync(Fase data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLFaseAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLFaseAsync(int idFase)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLFaseAsync(idFase);
    }


}
