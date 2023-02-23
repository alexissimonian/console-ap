using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Domain.Services;

public class PersonneService : IPersonneService
{
    private readonly IPersonneRepository _repository;

    public PersonneService(IPersonneRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Personne>> GetAllPersonnesAsync()
    {
        return await _repository.GetAllPersonnesAsync();
    }

    public async Task<Personne?> GetPersonneAsync(string id)
    {
        return await _repository.GetPersonneAsync(id);
    }

    public async Task<Personne?> CreatePersonneAsync(string nom, string prenom, DateTime dateDeNaissance)
    {
        if (DateTime.Today.Year - dateDeNaissance.Year > 150)
        {
            return null;
        }
        return await _repository.CreatePersonneAsync(nom, prenom, dateDeNaissance);
    }
}