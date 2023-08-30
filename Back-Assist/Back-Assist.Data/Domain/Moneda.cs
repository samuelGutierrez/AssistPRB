using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_Assist.Data.Domain
{
    public class Moneda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //Relaciones
        public virtual ICollection<Sucursales> Sucursales { get; set; }
    }
}
