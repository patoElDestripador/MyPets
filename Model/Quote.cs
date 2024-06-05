namespace MyPets.Model
{
    public class Quote
    {
        public int Id { get; set; }
        public DateOnly? Date { get; set; }
        public int? PetId { get; set; }
        public int? VetId { get; set; }
        
        public Pet Pet { get; set; }
        public Vet Vet { get; set; }

    }
}

