using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class Calificacion
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        */
        [Required]
        public int Valor { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuario { get; set; }

        public int IdReceta { get; set; }

    }
}
