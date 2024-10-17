using SKL.Repositories.IRepository;
using SKL.Services.IServices;
using SKL.Models;
using System.Xml.Linq;
using SKL.Models.ViewModels;

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
    /*---------------------------------------------------------------------------*/
    /*------------------------------------TASKS--------------------------------------*/
    public async Task<IEnumerable<Tasks>> GetSKLTasksAsync()
            => await _repository.GetSKLTasksAsync();
    public async Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedAsync()
        => await _repository.GetSKLTasksCompletedAsync();

    public async Task<TaskPerEval> GetSKLTask(int idTask)
    => await _repository.GetSKLTask(idTask);

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTaskPerUserFase(int idFase, int idUser)
            => await _repository.GetSKLTaskPerUserFase(idFase, idUser);

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTaskCompletedPerDept(int idFase, int idDepartment)
        => await _repository.GetSKLTaskCompletedPerDept(idFase, idDepartment);

    public async Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedPhaseAsync(int idFase)
        => await _repository.GetSKLTasksCompletedPhaseAsync(idFase);


    public async Task<(bool, string)> UpdateSKLTaskAsync(Tasks data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLTaskAsync(data);
    }

    //public async Task<(bool, string)> InsertSKLTaskAsync(Tasks tasks)
    //{
    //    _repository.DataChangeEventHandler += DataChangeEventHandler;
    //    return await _repository.InsertSKLTaskAsync(tasks);
    //}

    public async Task<(bool, string, int)> InsertSKLTaskAsync(Tasks tasks)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLTaskAsync(tasks);
    }


    public async Task<(bool, string)> DeleteSKLTaskAsync(int idTask)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLTaskAsync(idTask);
    }
    /*---------------------------------------------------------------------------*/
    /*------------------------------------EVAL--------------------------------------*/
    public async Task<IEnumerable<Eval>> GetSKLEvalsAsync()
    => await _repository.GetSKLEvalsAsync();

    public async Task<IEnumerable<Eval>> GetSKLEvalAsync(int idEval)
    => await _repository.GetSKLEvalAsync(idEval);

    public async Task<IEnumerable<Eval>> GetSKLEvalPerUserAsync(int IdUserE, int IdFaseE)
        => await _repository.GetSKLEvalPerUserAsync(IdUserE, IdFaseE);

    public async Task<(bool, string)> InsertSKLEvalAsync(Eval evaldata)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLEvalAsync(evaldata);
    }

    public async Task<(bool, string)> UpdateSKLEvalAsync(Eval data)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLEvalAsync(data);
    }

    public async Task<(bool, string)> DeleteSKLEvalAsync(int idEval)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLEvalAsync(idEval);
    }
    /*---------------------------------------------------------------------------*/
    /*---------------------------------EVIDENCES-----------------------------------*/
    public async Task<IEnumerable<Evidence>> GetSKLEvidencesAsync()
    => await _repository.GetSKLEvidencesAsync();

    public async Task<IEnumerable<Evidence>> GetSKLTaskEvidence(int idTask)
    => await _repository.GetSKLTaskEvidence(idTask);

    public async Task<Evidence> GetSKLEvidenceAsync(int idEvidences)
    => await _repository.GetSKLEvidenceAsync(idEvidences);

    public async Task<IEnumerable<TaskPerEvi>> GetSKLEviPerTaskAsync(int IdUserE, int IdFaseE)
    => await _repository.GetSKLEviPerTaskAsync(IdUserE, IdFaseE);

    public async Task<(bool, string)> InsertSKLEvidencesAsync(Evidence evidencedata)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLEvidencesAsync(evidencedata);
    }

    public async Task<(bool, string)> UpdateSKLEvidencesAsync(Evidence evidencedata)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLEvidencesAsync(evidencedata);
    }

    public async Task<(bool, string)> DeleteSKLEvidencesAsync(int idEvidences)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.DeleteSKLEvidencesAsync(idEvidences);
    }

    /*---------------------------------------------------------------------------*/
    /*---------------------------------CHARTS-----------------------------------*/

    public async Task<object> GetChartTasksCompletedAsync()
    {
        var chartList = new List<object>();
        var taskList = await GetSKLTasksCompletedAsync();



        var groupedTasks = taskList
            .Where(t => t.IsActive)
            .GroupBy(t => new { t.IdFaseT, t.FaseName })
            .Select(group => new
            {
                Phase = group.Key.FaseName,
                Completed = group.Count(t => t.IsCompleted),
                NotCompleted = group.Count(t => !t.IsCompleted),
            });

        foreach (var phaseData in groupedTasks)
        {
            var chartData = new
            {
                phase = phaseData.Phase,
                completed = phaseData.Completed,
                notCompleted = phaseData.NotCompleted
            };

            chartList.Add(chartData);
        }

        return chartList;
    }

    public async Task<object> GetChartTasksCompletedPerDeptAsync(int idFase, int idDepartment)
    {
        var chartList = new List<object>();
        var taskList = await GetSKLTaskCompletedPerDept(idFase, idDepartment);



        var groupedTasks = taskList
            .GroupBy(t => new { t.IdDepartment, t.DepartmentName })
            .Select(group => new
            {
                Department = group.Key.DepartmentName,
                Completed = group.Count(t => t.IsCompleted),
                NotCompleted = group.Count(t => !t.IsCompleted),
            });

        foreach (var phaseData in groupedTasks)
        {
            var chartData = new
            {
                department = phaseData.Department,
                completed = phaseData.Completed,
                notCompleted = phaseData.NotCompleted
            };

            chartList.Add(chartData);
        }

        return chartList;
    }
    /*---------------------------------------------------------------------------*/
    /*---------------------------------NOTIFICATIONS--------------------------------*/

    public async Task<IEnumerable<NotificationsViewModel>> GetSKLNotificationsAsync(int IdUser)
    => await _repository.GetSKLNotificationsAsync(IdUser);

    public async Task<(bool, string)> InsertSKLNotificationsAsync(Notifications notifications)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.InsertSKLNotificationsAsync(notifications);
    }

    public async Task<(bool, string)> UpdateSKLNotificationsAsync(Notifications notifications)
    {
        _repository.DataChangeEventHandler += DataChangeEventHandler;
        return await _repository.UpdateSKLNotificationsAsync(notifications);
    }

    /*---------------------------------------------------------------------------*/
    /*---------------------------------FUNCTIONS-----------------------------------*/
    public async Task<List<PercentagePerDeptViewModel>> GetPercentageTasksPerDept(int fase)
    {
        var taskList = await GetSKLTasksCompletedPhaseAsync(fase);

        var groupedTasks = taskList
            .GroupBy(t => new { t.IdDepartment, t.DepartmentName })  // Agrupamos por ID y Nombre del Departamento
            .Select(group => new PercentagePerDeptViewModel
            {
                DepartmentId = group.Key.IdDepartment,  // Asignamos el ID del departamento
                Department = group.Key.DepartmentName,
                PercentageCompleted = group.Count() > 0
                    ? $"{Math.Round((group.Count(t => t.IsCompleted) / (double)group.Count()) * 100, 2)}% Completado"
                    : "0% Completado"
            })
            .ToList();

        return groupedTasks;
    }



}
