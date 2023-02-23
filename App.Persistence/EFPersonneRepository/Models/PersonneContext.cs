using Microsoft.EntityFrameworkCore;

namespace App.Persistence.EFPersonneRepository.Models;

public class PersonneContext: DbContext
{
    public PersonneContext(DbContextOptions<PersonneContext> options)
        : base(options)
    {
    }

    public DbSet<PersonneData> PersonneDatas { get; set; } = null!; 
}