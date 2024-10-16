namespace SKL.Models.ViewModels
{
    public class ChartTaskDataViewModel
    {
        [Map("department_name")]
        public string Department { get; set; }  // Nombre del departamento
        [Map("id_usr_department")]
        public int DepartmentId { get; set; }
        public int CompletedTasks { get; set; }  // Número de tareas completadas
        public int NotCompletedTasks { get; set; }  // Número de tareas no completadas
    }

}
