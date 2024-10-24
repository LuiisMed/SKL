using SKL.Models.ViewModels;

namespace SKL.Models
{
    public class TaskPerEval
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

        /*-----------Email-------------*/
        [Map("Email")]
        public string? Email { get; set; }



        /*-----------Evals-------------*/
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
        /*-----------Evals-------------*/


        /*-----------Evidences-------------*/

        [Map("id_evidences")]
        public int IdEvidences { get; set; }
        [Map("evidences")]
        public string? Evidences { get; set; }
        [Map("id_eval")]
        /*-----------Evidences-------------*/


        public IEnumerable<Usuario>? Usuarios { get; set; }
        public IEnumerable<Aspect>? Aspectos { get; set; }
        public IEnumerable<Fase>? Fases { get; set; }
        public IEnumerable<Eval>? Evals { get; set; }
        public int IdFase { get; set; }
        public int IdDepartment { get; set; }
        public string? DepartmentName { get; set; }

        public List<PercentagePerDeptViewModel> PercentagePerDept { get; set; }  // Nueva propiedad


        [Display(Name = "Usuarios")]
        public int UserFilter { get; set; }
        [Display(Name = "Fases")]
        public int FaseFilter { get; set; }
        [Display(Name = "Departments")]
        public int DepartmentFilter { get; set; }
        [Display(Name = "Tasks")]
        public int TaskFocus { get; set; }

        //public IEnumerable<Fase> Fases { get; set; }
        //public IEnumerable<Usuario> Usuarios { get; set; }


    }
}
