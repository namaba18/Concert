using Concert.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Concert.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Usado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool WasUsed { get; set; }

        [Display(Name = "Document")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String? Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String? Name { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }

        [Display(Name = "Entrada")]
        public int? EntraceId { get; set; }

        public IEnumerable<SelectListItem>? Entrace { get; set; }
    }
}
