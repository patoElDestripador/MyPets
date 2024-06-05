using System.ComponentModel.DataAnnotations;

namespace MyPets.Model
{
    public class VetDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo Name es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo Phone es obligatorio")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo Addres es obligatorio")]
        public string Addres { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string Email { get; set; }
    }
}