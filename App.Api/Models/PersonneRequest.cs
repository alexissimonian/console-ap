namespace App.Api.Models;

public class PersonneRequest
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateDeNaissance { get; set; }
}