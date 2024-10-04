namespace SKL.Models
{
    public class TaskPerEvi
    {

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
        [Map("id_evidences")]
        public int IdEvidences { get; set; }
        [Map("evidences")]
        public string? Evidences { get; set; }


    }
}
