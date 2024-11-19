using Microsoft.Build.Framework;
using Microsoft.VisualBasic;
using SKL.Data;
using SKL.Models;
using SKL.Models.ViewModels;
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

    public async Task<IEnumerable<Fase>> GetSKLFaseName(int idFase)
    => await _context.ExecuteStoredProcedureQueryAsync<Fase>(_storedProcedure, new
    {
        Option = "GET_FASE",
        Param1 = idFase
    });

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

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<TaskPerEvi>(_storedProcedure,
    new { Option = "GET_TASKS_COMPLETED" });

    public async Task<IEnumerable<SKLTasksOverdue>> GetSKLTasksOverDueAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<SKLTasksOverdue>(_storedProcedure,
    new { Option = "GET_TASK_OVERDUE" });

    public async Task<TaskPerEval> GetSKLTask(int idTask)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<TaskPerEval>(_storedProcedure,
            new { Option = "GET_ONE_TASK", Param1 = idTask });
        return list.FirstOrDefault() ?? new() { Name = "" };
    }

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTaskPerUserFase(int idFase, int idUser)
    => await _context.ExecuteStoredProcedureQueryAsync<TaskPerEvi>(_storedProcedure, new
    {
        Option = "GET_TASK_PER_USER_FASE",
        Param1 = idFase,
        Param2 = idUser
    });

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedPhaseAsync(int idFase)
    => await _context.ExecuteStoredProcedureQueryAsync<TaskPerEvi>(_storedProcedure, new
    {
        Option = "GET_TASKS_COMPLETED_PER_PHASE",
        Param1 = idFase
    });

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTaskCompletedPerDept(int idFase, int idDepartment)
    => await _context.ExecuteStoredProcedureQueryAsync<TaskPerEvi>(_storedProcedure, new
    {
        Option = "GET_TASK_PER_FASE_DEPT",
        Param1 = idFase,
        Param2 = idDepartment
    });

    //public async Task<(bool, string)> InsertSKLTaskAsync(Tasks tasks)
    //{
    //    _context.DataChangeEventHandler += DataChangeEventHandler;
    //    return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
    //        new
    //        {
    //            Option = "INS_TASK",
    //            Param1 = tasks.IdTask,
    //            Param2 = tasks.IdUserT,
    //            Param3 = tasks.IdFaseT,
    //            Param4 = tasks.Accion,
    //            Param5 = tasks.IdAspect,
    //            Param6 = tasks.IsCompleted,
    //            Param7 = tasks.Start,
    //            Param8 = tasks.End

    //        });
    //}

    public async Task<(bool, string, int)> InsertSKLTaskAsync(Tasks tasks)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        var result = await _context.ExecuteStoredProcedureDMLAsync2(_storedProcedure,
            new
            {
                Option = "INS_TASK",
                Param1 = tasks.IdTask,
                Param2 = tasks.IdUserT,
                Param3 = tasks.IdFaseT,
                Param4 = tasks.Accion,
                Param5 = tasks.IdAspect,
                Param6 = tasks.IsCompleted,
                Param8 = tasks.End
            });

        // Suponiendo que el result contiene el ID de la tarea recién creada
        int newTaskId = result.NewTaskId; // Debes extraer esto del resultado de tu ejecución

        return (result.Error, result.Message, newTaskId);
    }



    public async Task<(bool, string)> UpdateSKLTaskAsync(Tasks tasks)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_TASK",
                Param1 = tasks.IdTask,
                Param2 = tasks.Accion,
                Param3 = tasks.IdAspect,
                Param4 = tasks.IsCompleted,
                Param6 = tasks.End

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

    public async Task<IEnumerable<Eval>> GetSKLEvalPerUserAsync(int IdUserE, int IdFaseE)
    => await _context.ExecuteStoredProcedureQueryAsync<Eval>(_storedProcedure, new
    {
        Option = "GET_EVAL_PER_USER",
        Param1 = IdUserE,
        Param2 = IdFaseE
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

    /*----------------------------------EVIDENCES------------------------------------*/
    public async Task<IEnumerable<Evidence>> GetSKLEvidencesAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<Evidence>(_storedProcedure,
    new { Option = "GET_EVIDENCES" });

    public async Task<IEnumerable<Evidence>> GetSKLTaskEvidence(int idTask)
    => await _context.ExecuteStoredProcedureQueryAsync<Evidence>(_storedProcedure, new
    {
        Option = "GET_TASK_EVIDENCE",
        Param1 = idTask
    });

    public async Task<IEnumerable<TaskPerEvi>> GetSKLEviPerTaskAsync(int IdUserE, int IdFaseE)
    =>  await _context.ExecuteStoredProcedureQueryAsync<TaskPerEvi>(_storedProcedure, new
    {
        Option = "GET_TASK_USER_FASE_EVI",
        Param1 = IdUserE,
        Param2 = IdFaseE
    });

    public async Task<Evidence> GetSKLEvidenceAsync(int idEvidences)
    {
        var list = await _context.ExecuteStoredProcedureQueryAsync<Evidence>(_storedProcedure,
            new { Option = "GET_ONE_TASK", Param1 = idEvidences });
        return list.FirstOrDefault() ?? new() { Evidences = "" };
    }

    public async Task<(bool, string)> InsertSKLEvidencesAsync(Evidence evidence)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_EVIDENCES",
                Param1 = evidence.Evidences,
                Param2 = evidence.IdTask

            });
    }

    public async Task<(bool, string)> UpdateSKLEvidencesAsync(Evidence evidence)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_EVIDENCES",
                Param1 = evidence.IdEvidences,
                Param2 = evidence.Evidences,
                Param3 = evidence.IdTask

            });
    }

    public async Task<(bool, string)> DeleteSKLEvidencesAsync(int idEvidences)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "DEL_EVIDENCES",
                Param1 = idEvidences
            });
    }
    /*----------------------------------NOTIFICATIONS------------------------------------*/

    public async Task<IEnumerable<NotificationsViewModel>> GetSKLNotificationsAsync(int IdUser)
    => await _context.ExecuteStoredProcedureQueryAsync<NotificationsViewModel>(_storedProcedure, new
    {
        Option = "GET_USER_NOTIFICATION",
        Param1 = IdUser
    });

    public async Task<IEnumerable<NotificationsViewModel>> GetSKLAdminNotificationsAsync()
    => await _context.ExecuteStoredProcedureQueryAsync<NotificationsViewModel>(_storedProcedure, new
    {
        Option = "GET_ADMIN_NOTIFICATION"
    });

    public async Task<(bool, string)> InsertSKLNotificationsAsync(Notifications notifications)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "INS_NOTIFICATION",
                Param1 = notifications.IdTask,
                Param2 = notifications.IdUsr,
                Param3 = notifications.IsReaded,
                Param4 = notifications.Message,
                Param5 = notifications.EviReaded
            });
    }

    public async Task<(bool, string)> UpdateSKLNotificationsAsync(Notifications notifications)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_NOTIFICATION",
                Param1 = notifications.IdNotification,
                Param2 = notifications.IsReaded
            });
    }

    public async Task<(bool, string)> UpdateSKLAdminNotificationsAsync(Notifications notifications)
    {
        _context.DataChangeEventHandler += DataChangeEventHandler;
        return await _context.ExecuteStoredProcedureDMLAsync(_storedProcedure,
            new
            {
                Option = "UPD_ADMIN_NOTIFICATION",
                Param1 = notifications.IdNotification,
                Param2 = notifications.EviReaded
            });
    }


}
