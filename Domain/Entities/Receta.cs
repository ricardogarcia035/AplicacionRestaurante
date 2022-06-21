using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Receta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public string Ingredientes { get; set; }

        [Required]
        public string Instrucciones { get; set; }

        [Required]
        public string DireccionFoto { get; set; }//FotoUrl

        public DateTime Fecha { get; set; }

        public int IdUsuario { get; set; }

        public virtual List<Categoria> Categorias { get; set; }

        public virtual List<Calificacion> Calificaciones { get; set; }

        public bool Estado { get; set; }

       
        [NotMapped]
        public double? Calificacion{
            get
            {
                if (!(this.Calificaciones is null) && this.Calificaciones.Count > 0)
                {
                    return this.Calificaciones.Average(x => x.Valor);
                }
                return null;
               
            }
        }//
    }
}
