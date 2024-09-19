#nullable disable

namespace SKL.Models
{
    public class Login
    {
        [Map("name")]
        public string Name { get; set; }
        [Map("usr_name")]
        public string Usuario { get; set; }
        [Map("usr_pass")]
        public string Clave { get; set; }
        [Map("id_usr_type")]
        public int Rol { get; set; }
        [Map("usr_type_name")]
        public string RolName { get; set; }
        [Map("usr_img")]
        public string ImagePath { get; set; }

    }
}
