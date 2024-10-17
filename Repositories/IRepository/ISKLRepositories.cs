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
    /*---------------------------------------------------------------------------*/
    /*----------------------------------ASPECTS------------------------------------*/
    Task<IEnumerable<Aspect>> GetSKLAspectsAsync();
    Task<Aspect> GetSKLAspectAsync(int idAspect);
    Task<(bool, string)> InsertSKLAspectAsync(Aspect aspect);
    Task<(bool, string)> UpdateSKLAspectAsync(Aspect aspect);
    Task<(bool, string)> DeleteSKLAspectAsync(int idAspect);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------FASE--------------------------------------*/
    Task<IEnumerable<Fase>> GetSKLFasesAsync();
    Task<Fase> GetSKLFaseAsync(int idFase);
    Task<(bool, string)> InsertSKLFaseAsync(Fase fase);
    Task<(bool, string)> UpdateSKLFaseAsync(Fase fase);
    Task<(bool, string)> DeleteSKLFaseAsync(int idFase);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------TASKS--------------------------------------*/
    Task<IEnumerable<Tasks>> GetSKLTasksAsync();
    Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedAsync();
    Task<TaskPerEval> GetSKLTask(int idTask);
    Task<IEnumerable<TaskPerEvi>> GetSKLTaskPerUserFase(int idFase, int idUser);
    Task<IEnumerable<TaskPerEvi>> GetSKLTaskCompletedPerDept(int idFase, int idDepartment);
    Task<IEnumerable<TaskPerEvi>> GetSKLTasksCompletedPhaseAsync(int idFase);
    //Task<(bool, string)> InsertSKLTaskAsync(Tasks tasks);
    Task<(bool, string, int)> InsertSKLTaskAsync(Tasks tasks);
    Task<(bool, string)> UpdateSKLTaskAsync(Tasks tasks);
    Task<(bool, string)> DeleteSKLTaskAsync(int idTask);
    /*---------------------------------------------------------------------------*/
    /*------------------------------------EVAL--------------------------------------*/
    Task<IEnumerable<Eval>> GetSKLEvalsAsync();
    Task<IEnumerable<Eval>> GetSKLEvalAsync(int idEval);
    Task<IEnumerable<Eval>> GetSKLEvalPerUserAsync(int IdUserE, int IdFaseE);
    Task<(bool, string)> InsertSKLEvalAsync(Eval eval);
    Task<(bool, string)> UpdateSKLEvalAsync(Eval eval);
    Task<(bool, string)> DeleteSKLEvalAsync(int idEval);
    /*---------------------------------------------------------------------------*/
    /*----------------------------------EVIDENCES------------------------------------*/
    Task<IEnumerable<Evidence>> GetSKLEvidencesAsync();
    Task<IEnumerable<Evidence>> GetSKLTaskEvidence(int idTask);
    Task<IEnumerable<TaskPerEvi>> GetSKLEviPerTaskAsync(int IdUserE, int IdFaseE);
    Task<Evidence> GetSKLEvidenceAsync(int idEvidences);
    Task<(bool, string)> InsertSKLEvidencesAsync(Evidence evidence);
    Task<(bool, string)> UpdateSKLEvidencesAsync(Evidence evidence);
    Task<(bool, string)> DeleteSKLEvidencesAsync(int idEvidences);
    /*---------------------------------------------------------------------------*/
    /*----------------------------------Notifications------------------------------------*/
    Task<IEnumerable<Notifications>> GetSKLNotificationsAsync(int IdUser);
    Task<(bool, string)> InsertSKLNotificationsAsync(Notifications notifications);
    Task<(bool, string)> UpdateSKLNotificationsAsync(Notifications notifications);
}
