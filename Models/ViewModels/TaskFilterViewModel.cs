namespace SKL.Models.ViewModels
{
    public class TaskFilterViewModel
    {
        [Display (Name = "Usuarios")]
        public int UserFilter {  get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }

    }
}
