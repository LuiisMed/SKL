#nullable disable

namespace SKL.Models;

public class Department
{
    [Map("id_department")]
    public int Id { get; set; }
    [Map("department_name")]
    public string Name { get; set; }

}