namespace SKL.Models.ViewModels
{
    public class NotificationsViewModel
    {

        [Map("id_notification")]
        public int IdNotification { get; set; }
        [Map("id_task")]
        public int IdTask { get; set; }
        [Map("id_usr")]
        public int IdUsr { get; set; }
        [Map("name")]
        public string NameUser { get; set; }
        [Map("emp_no")]
        public int EmpNum { get; set; }
        [Map("id_usr_department")]
        public int IdDepartment { get; set; }
        [Map("isReaded")]
        public Boolean IsReaded { get; set; }
        [Map("EviReaded")]
        public Boolean EviReaded { get; set; }
        [Map("message")]
        public string? Message { get; set; }
        [Map("accion")]
        public string? Accion { get; set; }
        [Map("id_fase")]
        public int IdFase { get; set; }
        [Map("fase_name")]
        public string? FaseName { get; set; }
    }
}
