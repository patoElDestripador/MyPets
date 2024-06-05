using System.ComponentModel.DataAnnotations;

namespace MyPets.Model
{
    public class OwnerDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "El campo Names es obligatorio")]
        public string Names { get; set; }
        [Required(ErrorMessage = "El campo LastNames es obligatorio")]
        public string LastNames { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Addres es obligatorio")]
        public string Addres { get; set; }
        [Required(ErrorMessage = "El campo Phone es obligatorio")]
        public string Phone { get; set; }
    }
}
