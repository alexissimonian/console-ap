using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Persistence.EFPersonneRepository.Models;

public class PersonneData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateDeNaissance { get; set; }
}