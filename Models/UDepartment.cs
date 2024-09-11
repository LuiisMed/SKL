#nullable disable

namespace SKL.Models
{
    public class UDepartment
    {
        public int IdDepartment { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
