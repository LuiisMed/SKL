namespace SKL.Models
{
    public class SKLTasksOverdue
    {
        [Map("id_task")]
        public int IdTask { get; set; }
        [Map("id_usr")]
        public int IdUser { get; set; }
        [Map("name")]
        public string? Name { get; set; }
        [Map("Email")]
        public string? Email { get; set; }
        [Map("id_fase")]
        public int IdFase { get; set; }
        [Map("fase_name")]
        public string? FaseName { get; set; }
        [Map("accion")]
        public string? Accion { get; set; }
        [Map("isCompleted")]
        public Boolean IsCompleted { get; set; }
        [Map("task_start")]
        public DateTime Start { get; set; }
        [Map("task_end")]
        public DateTime End { get; set; }
        [Map("id_evidences")]
        public int IdEvidences { get; set; }
        [Map("evidences")]
        public string? Evidences { get; set; }
        public int DiasRestantes { get; set; }
    }
}
