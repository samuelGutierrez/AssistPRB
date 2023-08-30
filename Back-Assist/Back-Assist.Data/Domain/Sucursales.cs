using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_Assist.Data.Domain
{
    public class Sucursales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }
        [Required]
        [MaxLength(250)]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(50)]
        public string Identificacion { get; set; }
        public int MonedaId { get; set; }
        public DateTime FechaCreacion { get; set; }


        //Relaciones
        [ForeignKey("MonedaId")]
        public virtual Moneda Monedas { get; set; }

        public virtual ICollection<LogSucursal> LogSucursal { get; set; }
    }
}
