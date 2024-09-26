using Microsoft.VisualBasic;
using SKL.Data;
using SKL.Models;
using SKL.Repositories.IRepository;
using System.Xml.Linq;

namespace SKL.Repositories;

public class SKLRepository : ISKLRepositories
{
    public event EventHandler? DataChangeEventHandler;
    private readonly SkipLevelContext _context;
    private readonly string _storedProcedure;

    public SKLRepository(SkipLevelContext context)
    {
        _storedProcedure = "[SKL].[SKL_FUNCTIONS]";
        _context = context;
    }

    /*--------------------------------DEPARTMENTS----------------------------------*/
    public async Task<IEnumerable<Department>> GetSKLDepartmentsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Department>(_storedProcedure,
    new { Option = "GET_DEPARTMENT" });

    public async Task<Department> GetSKLDepartmentAsync(int idDepartment)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<Department>(_storedProcedure,
            new { Option = "GET_ONE_DEPARTMENT", Param1 = idDepartment });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<(bool, string)> InsertSKLDepartmentsAsync(Department department)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_DEPARTMENT",
                Param1 = department.Name
            });
    }

    public async Task<(bool, string)> UpdateSKLDepartmentsAsync(Department department)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_DEPARTMENT",
                Param1 = department.Id,
                Param2 = department.Name

            });
    }

    public async Task<(bool, string)> DeleteSKLDepartmentsAsync(int Id)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_DEPARTMENT",
                Param1 = Id
            });
    }
    /*------------------------------------------------------------------------------*/
    /*-----------------------------------USERTYPE-----------------------------------*/
    public async Task<IEnumerable<UserType>> GetSKLUserTypesAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<UserType>(_storedProcedure,
    new { Option = "GET_USERTYPE" });

    public async Task<UserType> GetSKLUsertypeAsync(int idUsertype)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<UserType>(_storedProcedure,
            new { Option = "GET_ONE_USERTYPE", Param1 = idUsertype });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<(bool, string)> InsertSKLUsertypesAsync(UserType userType)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_USERTYPE",
                Param1 = userType.Name
            });
    }

    public async Task<(bool, string)> UpdateSKLUsertypesAsync(UserType userType)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_USERTYPE",
                Param1 = userType.Id,
                Param2 = userType.Name

            });
    }

    public async Task<(bool, string)> DeleteSKLUsertypesAsync(int idUsertype)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_USERTYPE",
                Param1 = idUsertype
            });
    }
    /*------------------------------------------------------------------------------*/
    /*------------------------------------SHIFT-------------------------------------*/
    public async Task<IEnumerable<Shift>> GetSKLShiftsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Shift>(_storedProcedure,
    new { Option = "GET_SHIFTS" });

    public async Task<Shift> GetSKLShiftAsync(int idShift)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<Shift>(_storedProcedure,
            new { Option = "GET_ONE_SHIFT", Param1 = idShift });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<(bool, string)> InsertSKLShiftsAsync(Shift shift)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_SHIFTS",
                Param1 = shift.Name,
                Param2 = shift.Start,
                Param3 = shift.End
            });
    }

    public async Task<(bool, string)> UpdateSKLShiftsAsync(Shift shift)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_SHIFTS",
                Param1 = shift.Id,
                Param2 = shift.Name,
                Param3 = shift.Start,
                Param4 = shift.End

            });
    }

    public async Task<(bool, string)> DeleteSKLShiftsAsync(int idShift)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_SHIFTS",
                Param1 = idShift
            });
    }
    /*------------------------------------------------------------------------------*/
    /*----------------------------------POSITION------------------------------------*/
    public async Task<IEnumerable<Position>> GetSKLPositionsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Position>(_storedProcedure,
    new { Option = "GET_POSITION" });

    public async Task<Position> GetSKLPositionAsync(int idPosition)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<Position>(_storedProcedure,
            new { Option = "GET_ONE_POSITION", Param1 = idPosition });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<(bool, string)> InsertSKLPositionAsync(Position position)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_POSITION",
                Param1 = position.Name

            });
    }

    public async Task<(bool, string)> UpdateSKLPositionAsync(Position position)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_POSITION",
                Param1 = position.Id,
                Param2 = position.Name

            });
    }

    public async Task<(bool, string)> DeleteSKLPositionAsync(int idPosition)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_POSITION",
                Param1 = idPosition
            });
    }
    /*------------------------------------------------------------------------------*/
    /*----------------------------------ASPECTS------------------------------------*/
    public async Task<IEnumerable<Aspect>> GetSKLAspectsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Aspect>(_storedProcedure,
    new { Option = "GET_ASPECT" });

    public async Task<Aspect> GetSKLAspectAsync(int idAspect)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<Aspect>(_storedProcedure,
            new { Option = "GET_ONE_ASPECT", Param1 = idAspect });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<(bool, string)> InsertSKLAspectAsync(Aspect aspect)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_ASPECT",
                Param1 = aspect.Name

            });
    }

    public async Task<(bool, string)> UpdateSKLAspectAsync(Aspect aspect)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_ASPECT",
                Param1 = aspect.Id,
                Param2 = aspect.Name

            });
    }

    public async Task<(bool, string)> DeleteSKLAspectAsync(int idAspect)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_ASPECT",
                Param1 = idAspect
            });
    }
    /*------------------------------------------------------------------------------*/
    /*------------------------------------FASE--------------------------------------*/
    public async Task<IEnumerable<Fase>> GetSKLFasesAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Fase>(_storedProcedure,
    new { Option = "GET_FASE" });

    public async Task<Fase> GetSKLFaseAsync(int idFase)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<Fase>(_storedProcedure,
            new { Option = "GET_ONE_FASE", Param1 = idFase });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<(bool, string)> InsertSKLFaseAsync(Fase fase)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_FASE",
                Param1 = fase.Name,
                Param2 = fase.Start,
                Param3 = fase.End,
                Param4 = fase.IsActive

            });
    }

    public async Task<(bool, string)> UpdateSKLFaseAsync(Fase fase)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_FASE",
                Param1 = fase.Id,
                Param2 = fase.Name,
                Param3 = fase.Start,
                Param4 = fase.End,
                Param5 = fase.IsActive

            });
    }

    public async Task<(bool, string)> DeleteSKLFaseAsync(int idFase)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_FASE",
                Param1 = idFase
            });
    }

    /*------------------------------------TASKS--------------------------------------*/
    public async Task<IEnumerable<Tasks>> GetSKLTasksAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Tasks>(_storedProcedure,
    new { Option = "GET_TASK" });

    public async Task<IEnumerable<Tasks>> GetSKLTaskPerUserFase(int idFase, int idUser)
    => await _context.ExecuteStoredProcedureQueryAsync<Tasks>(_storedProcedure, new
    {
        Option = "GET_TASK_PER_USER_FASE",
        Param1 = idFase,
        Param2 = idUser
    });

    public async Task<(bool, string)> InsertSKLTaskAsync(Tasks tasks)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_TASK",
                Param1 = tasks.IdUserT,
                Param2 = tasks.IdFaseT,
                Param3 = tasks.Accion,
                Param4 = tasks.IdAspect,
                Param5 = tasks.IdEvidences

            });
    }

    public async Task<(bool, string)> UpdateSKLTaskAsync(Tasks tasks)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_TASK",
                Param1 = tasks.Id,
                Param2 = tasks.IdUserT,
                Param3 = tasks.IdFaseT,
                Param4 = tasks.Accion,
                Param5 = tasks.IdAspect,
                Param6 = tasks.IdEvidences

            });
    }

    public async Task<(bool, string)> DeleteSKLTaskAsync(int idTask)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_TASK",
                Param1 = idTask
            });
    }

    /*------------------------------------EVAL--------------------------------------*/
    public async Task<IEnumerable<Eval>> GetSKLEvalsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Eval>(_storedProcedure,
    new { Option = "GET_EVAL" });


    public async Task<IEnumerable<Eval>> GetSKLEvalAsync(int idEval)
    => await _context.ExecuteStoredProcedureQueryAsync<Eval>(_storedProcedure, new
    {
        Option = "GET_ONE_EVAL",
        Param1 = idEval
    });

    public async Task<(bool, string)> InsertSKLEvalAsync(Eval eval)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_EVAL",
                Param1 = eval.IdUserE,
                Param2 = eval.IdFaseE,
                Param3 = eval.UserEval,
                Param4 = eval.Comentario,
                Param5 = eval.Results

            });
    }

    public async Task<(bool, string)> UpdateSKLEvalAsync(Eval eval)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_EVAL",
                Param1 = eval.Id,
                Param2 = eval.IdUserE,
                Param3 = eval.IdFaseE,
                Param4 = eval.UserEval,
                Param5 = eval.Comentario,
                Param6 = eval.Results

            });
    }

    public async Task<(bool, string)> DeleteSKLEvalAsync(int idEval)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_EVAL",
                Param1 = idEval
            });
    }

}
