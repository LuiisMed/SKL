namespace SKL.Models
{
    public class TaskPerEval
    {
        [Map("id_task")]
        public int IdTask { get; set; }
        [Map("id_usr")]
        public int IdUserT { get; set; }
        [Map("name")]
        public string Name { get; set; }
        [Map("id_fase")]
        public int IdFaseT { get; set; }
        [Map("fase_name")]
        public string FaseName { get; set; }
        [Map("accion")]
        public string? Accion { get; set; }
        [Map("id_aspect")]
        public int IdAspect { get; set; }
        [Map("aspect_name")]
        public string AspectName { get; set; }
        [Map("id_evidences")]
        public int IdEvidences { get; set; }
        [Map("id_eval")]
        public int IdEval { get; set; }
        [Map("emp_no")]
        public int IdUserE { get; set; }
        [Map("id_fase")]
        public int IdFaseE { get; set; }
        [Map("eval")]
        public Decimal UserEval { get; set; }
        [Map("comment")]
        public string? Comentario { get; set; }
        [Map("eval_file")]
        public string? Results { get; set; }


        public IEnumerable<Usuario>? Usuarios { get; set; }
        public IEnumerable<Aspect>? Aspectos { get; set; }
        public IEnumerable<Eval>? Evals { get; set; }

        [Display(Name = "Usuarios")]
        public int UserFilter { get; set; }
        [Display(Name = "Fases")]
        public int FaseFilter { get; set; }

        //public IEnumerable<Fase> Fases { get; set; }
        //public IEnumerable<Usuario> Usuarios { get; set; }


    }
}
