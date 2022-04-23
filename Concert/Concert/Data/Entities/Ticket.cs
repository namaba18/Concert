using System.ComponentModel.DataAnnotations;

namespace Concert.Data.Entities
{
    public class Ticket
    {
        
        public int Id { get; set; }
        
        [Display(Name = "Usado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool WasUsed { get; set; }

        [Display(Name = "Document")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public String? Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public String? Name { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }

        public Entrace? Entrace { get; set; }
    }
}
