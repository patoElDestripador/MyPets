namespace MyPets.Model
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public DateOnly? DateBirth { get; set; }
        public int? OwnerId { get; set; }
        public string? Photo { get; set; }
        public Owner Owner { get; set; }
    }
}
