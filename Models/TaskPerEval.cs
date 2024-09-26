namespace SKL.Models
{
    public class TaskPerEval
    {
        [Map("id_task")]
        public int Id { get; set; }
        [Map("id_usr")]
        public int IdUserT { get; set; }
        [Map("id_fase")]
        public int IdFaseT { get; set; }
        [Map("accion")]
        public string Accion { get; set; }
        [Map("id_aspect")]
        public int IdAspect { get; set; }
        [Map("id_evidences")]
        public int IdEvidences { get; set; }

        [Map("id_eval")]
        public int IdEval { get; set; }
        [Map("emp_no")]
        public int IdUserE { get; set; }
        [Map("id_fase")]
        public int IdFaseE { get; set; }
        [Map("eval")]
        public string UserEval { get; set; }
        [Map("comment")]
        public string Comentario { get; set; }
        [Map("eval_file")]
        public string? Results { get; set; }

    }
}
