using System.Text.Json.Serialization;

namespace MyPets.Model
{
    public class Vet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Addres { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public List<Quote> Quote { get; set; }
    }
}

