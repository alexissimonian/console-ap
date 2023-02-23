using App.Domain.Models;

namespace App.Domain.Interfaces;

public interface IPersonneRepository
{
    public Task<Personne?> GetPersonneAsync(string id);
    public Task<IEnumerable<Personne>> GetAllPersonnesAsync();
    public Task<Personne> CreatePersonneAsync(string nom, string prenom, DateTime dateDeNaissance);
}