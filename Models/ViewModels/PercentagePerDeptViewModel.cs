namespace SKL.Models.ViewModels
{
    public class PercentagePerDeptViewModel
    {
        [Map("department_name")]
        public string Department { get; set; }
        [Map("id_usr_department")]
        public int DepartmentId { get; set; }
        public double PercentageCompleted { get; set; }
        public double PercentageNotCompleted { get; set; }
        public double Pending {  get; set; }

    }
}
