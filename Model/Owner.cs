using System.Text.Json.Serialization;

namespace MyPets.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string? Names { get; set; }
        public string? LastNames { get; set; }
        public string? Email { get; set; }
        public string? Addres { get; set; }
        public string? Phone { get; set; }

        [JsonIgnore]
        public List<Pet> Pet { get; set; }
    }
}
