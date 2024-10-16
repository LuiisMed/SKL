namespace SKL.Models.ViewModels
{
    public class PercentagePerDeptViewModel
    {
        [Map("department_name")]
        public string Department { get; set; }
        [Map("id_usr_department")]
        public int DepartmentId { get; set; }
        public string PercentageCompleted { get; set; }
    }
}
