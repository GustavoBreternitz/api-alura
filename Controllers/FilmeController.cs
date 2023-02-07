using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Primeira_API.Data;
using Primeira_API.Data.Dtos;
using Primeira_API.Models;


namespace Primeira_API.Controllers;

[ApiController]
[Route("[controller]")]
public class filmeController : ControllerBase
{
    private FilmesContext _context;
    private IMapper _imapper;

    public filmeController(FilmesContext context, IMapper imapper)
    {
        _context = context;
        _imapper = imapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public CreatedAtActionResult create([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _imapper.Map<Filme>(filmeDto);   
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(readbyid), new {id = filme.id}, filme);
    }

    [HttpGet("[action]")]
    public IEnumerable<ReadFilmeDto> read([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _imapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult readbyid(int id)
    {
        var response = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        return response == null ? NotFound() : Ok(_imapper.Map<ReadFilmeDto>(response));
    }

    [HttpPut("{id}")]
    public IActionResult edit(int id, [FromBody] EditFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        if(filme == null) {
            return NotFound();  
        }

        _context.Filmes.Update(_imapper.Map(filmeDto, filme));
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult delete(int id) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
        if (filme == null)
        {
            return NotFound();
        }

        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
