using SKL.Models;

namespace SKL.Services.IServices;

public interface ITaskReminderHostedServices
{
    Task<IEnumerable<TaskPerEvi>> GetSKLTasksOverDueAsync();

}
