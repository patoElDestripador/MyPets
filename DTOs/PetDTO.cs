using System.ComponentModel.DataAnnotations;

namespace MyPets.Model
{
    public class PetDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo Name es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo Specie es obligatorio")]
        public string Specie { get; set; }
        [Required(ErrorMessage = "El campo Race es obligatorio")]
        public string Race { get; set; }
        [Required(ErrorMessage = "El campo DateBirth es obligatorio")]
        public DateOnly DateBirth { get; set; }
        [Required(ErrorMessage = "El campo OwnerId es obligatorio")]
        public int OwnerId { get; set; }
        public string Photo { get; set; }
    }
}
