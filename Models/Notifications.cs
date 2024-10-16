namespace SKL.Models
{
    public class Notifications
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
    }
}
