using SKL.Models;
using SKL.Models.ViewModels;

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
    /*---------------------------------------------------------------------------*/
    /*------------------------------------TASKS--------------------------------------*/
    Task<IEnumerable<Tasks>> GetSKLTasksAsync();
    Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedAsync();
    Task<TaskPerEval> GetSKLTask(int idTask);
    Task<IEnumerable<TaskPerEvi>> GetSKLTaskPerUserFase(int idFase, int idUser);
    Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedPhaseAsync(int idFase);
    Task<IEnumerable<TaskPerEvi>> GetSKLTaskCompletedPerDept(int idFase, int idDepartment);
    //Task<(bool, string)> InsertSKLTaskAsync(Tasks tasks);
    Task<(bool, string, int)> InsertSKLTaskAsync(Tasks tasks);
    Task<(bool, string)> UpdateSKLTaskAsync(Tasks data);
    Task<(bool, string)> DeleteSKLTaskAsync(int idTask);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------EVAL--------------------------------------*/
    Task<IEnumerable<Eval>> GetSKLEvalsAsync();
    Task<IEnumerable<Eval>> GetSKLEvalAsync(int idEval);
    Task<IEnumerable<Eval>> GetSKLEvalPerUserAsync(int IdUserE, int IdFaseE);
    Task<(bool, string)> InsertSKLEvalAsync(Eval evaldata);
    Task<(bool, string)> UpdateSKLEvalAsync(Eval data);
    Task<(bool, string)> DeleteSKLEvalAsync(int idEval);

    /*---------------------------------------------------------------------------*/
    /*---------------------------------EVIDENCES-----------------------------------*/
    Task<IEnumerable<Evidence>> GetSKLEvidencesAsync();
    Task<IEnumerable<Evidence>> GetSKLTaskEvidence(int idTask);
    Task<Evidence> GetSKLEvidenceAsync(int idEvidences);
    Task<IEnumerable<TaskPerEvi>> GetSKLEviPerTaskAsync(int idFase, int idUser);
    Task<(bool, string)> InsertSKLEvidencesAsync(Evidence evidencedata);
    Task<(bool, string)> UpdateSKLEvidencesAsync(Evidence evidencedata);
    Task<(bool, string)> DeleteSKLEvidencesAsync(int idEvidences);
    /*---------------------------------------------------------------------------*/
    /*---------------------------------NOTIFICATIONS-----------------------------------*/
    Task<IEnumerable<NotificationsViewModel>> GetSKLNotificationsAsync(int IdUser);
    Task<(bool, string)> InsertSKLNotificationsAsync(Notifications notifications);
    Task<(bool, string)> UpdateSKLNotificationsAsync(Notifications notifications);
    /*---------------------------------------------------------------------------*/
    /*---------------------------------CHARTS-----------------------------------*/
    Task<object> GetChartTasksCompletedAsync();
    Task<object> GetChartTasksCompletedPerDeptAsync(int idFase, int idDepartment);
    Task<List<PercentagePerDeptViewModel>> GetPercentageTasksPerDept(int fase);
    Task<object> GetStackedColumnChartDataAsync(int idFase, int idDepartment);



}

