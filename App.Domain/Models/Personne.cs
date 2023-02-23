namespace App.Domain.Models;

public class Personne
{
    private Personne(string id, string nom, string prenom, DateTime dateDeNaissance)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        DateDeNaissance = dateDeNaissance;
    }
    
    public string Id { get; }
    public string Nom { get; }
    public string Prenom { get; }
    public DateTime DateDeNaissance { get; }

    public static Personne Create(string id, string nom, string prenom, DateTime dateDeNaissance)
    {
        return new Personne(id, nom, prenom, dateDeNaissance);
    }
}