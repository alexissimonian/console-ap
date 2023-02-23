using App.Api.Models;
using App.Domain.Interfaces;
using App.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonneController : ControllerBase
{
    private readonly IPersonneService _service;

    public PersonneController(IPersonneService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<PersonneApi>>> GetAllPersonnesAsync()
    {
        var personnes = await _service.GetAllPersonnesAsync();
        return Ok(personnes.Select(ConvertToPersonneApi));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonneApi>> GetSpecificPersonneAsync(string id)
    {
        var personne = await _service.GetPersonneAsync(id);
        return Ok(ConvertToPersonneApi(personne));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonneApi>> CreatePersonneAsync(PersonneRequest request)
    {
        var personne = await _service.CreatePersonneAsync(request.Nom, request.Prenom, request.DateDeNaissance);
        if (personne is null)
        {
            return BadRequest("Votre âge ne peut dépasser 150 ans.");
        }
        return Ok(personne);
    }

    private PersonneApi ConvertToPersonneApi(Personne personne)
    {
        return new PersonneApi()
        {
            Id = personne.Id, Nom = personne.Nom, Prenom = personne.Prenom,
            Age = DateTime.Today.Year - personne.DateDeNaissance.Year
        };
    }
}