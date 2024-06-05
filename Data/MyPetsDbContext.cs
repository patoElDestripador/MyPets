using MyPets.Model;
using Microsoft.EntityFrameworkCore;

namespace MyPets.Data 
{
    public class MyPetsDbContext : DbContext
    {
        public MyPetsDbContext(DbContextOptions<MyPetsDbContext> options) : base(options){
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Vet> Vets { get; set; }
    }
}