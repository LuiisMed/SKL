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
        [Map("isReaded")]
        public Boolean IsReaded { get; set; }
        [Map("message")]
        public string? Message { get; set; }
        [Map("id_fase")]
        public int IdFase { get; set; }
        [Map("fase_name")]
        public string? FaseName { get; set; }
    }
}
