namespace SKL.Models
{
    public class Eval
    {
        [Map("id_eval")]
        public int Id { get; set; }
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
    }
}
