using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Assist.Data.Domain
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //Relaciones
        public virtual ICollection<LogSucursal> LogSucursal { get; set; }
    }
}
