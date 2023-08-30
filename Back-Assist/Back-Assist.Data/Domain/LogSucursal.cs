using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_Assist.Data.Domain
{
    public class LogSucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CodigoSucursal { get; set; }
        public int IdUsuario { get; set; }
        public string TipoOperacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("Codigo")]
        public virtual Sucursales Sucursales { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
    }
}
