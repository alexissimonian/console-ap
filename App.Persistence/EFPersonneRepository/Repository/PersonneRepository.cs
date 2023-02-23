using App.Domain.Interfaces;
using App.Domain.Models;
using App.Persistence.EFPersonneRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.EFPersonneRepository.Repository;

public class PersonneRepository : IPersonneRepository
{
    private readonly PersonneContext _context;

    public PersonneRepository(PersonneContext context)
    {
        _context = context;
    }
    public async Task<Personne?> GetPersonneAsync(string id)
    {
        var personneId = Guid.Parse(id);
        var personneData = await _context.PersonneDatas.FindAsync(personneId);
        return personneData == null ? null : Personne.Create(personneData.Id, personneData.Nom, personneData.Prenom, personneData.DateDeNaissance);
    }

    public async Task<IEnumerable<Personne>> GetAllPersonnesAsync()
    {
        var personnesData = await _context.PersonneDatas.ToListAsync();
        var personnes = personnesData.Select(p => Personne.Create(p.Id, p.Nom, p.Prenom, p.DateDeNaissance));
        return personnes;
    }

    public async Task<Personne> CreatePersonneAsync(string nom, string prenom, DateTime dateDeNaissance)
    {
        var personneData = new PersonneData()
            { Nom = nom, Prenom = prenom, DateDeNaissance = dateDeNaissance };
        var personneDataEntry = _context.PersonneDatas.Add(personneData);
        await _context.SaveChangesAsync();
        return Personne.Create(personneDataEntry.Entity.Id, personneDataEntry.Entity.Nom, personneDataEntry.Entity.Prenom, personneDataEntry.Entity.DateDeNaissance);
    }
}