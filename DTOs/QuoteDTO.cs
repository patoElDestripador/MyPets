using System.ComponentModel.DataAnnotations;

namespace MyPets.Model
{
    public class QuoteDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo DateOnly es obligatorio")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "El campo PetId es obligatorio")]
        public int PetId { get; set; }
        [Required(ErrorMessage = "El campo VetId es obligatorio")]
        public int VetId { get; set; }
    }
}