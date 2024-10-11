namespace SKL.Models
{
    public class TaskPerEvi
    {
        /*-----------Task-------------*/
        [Map("id_task")]
        public int IdTask { get; set; }
        [Map("id_usr")]
        public int IdUserT { get; set; }
        [Map("name")]
        public string? Name { get; set; }
        [Map("id_fase")]
        public int IdFaseT { get; set; }
        [Map("fase_name")]
        public string? FaseName { get; set; }
        [Map("accion")]
        public string? Accion { get; set; }
        [Map("id_aspect")]
        public int IdAspect { get; set; }
        [Map("aspect_name")]
        public string? AspectName { get; set; }
        [Map("isCompleted")]
        public Boolean IsCompleted { get; set; }
        [Map("task_start")]
        public DateTime Start { get; set; }
        [Map("task_end")]
        public DateTime End { get; set; }
        /*-----------Task-------------*/


        /*-----------Evidences-------------*/

        [Map("id_evidences")]
        public int IdEvidences { get; set; }
        [Map("evidences")]
        public string? Evidences { get; set; }
        /*-----------Evidences-------------*/


    }
}
