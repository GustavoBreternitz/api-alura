using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Primeira_API.Data;
using Primeira_API.Data.Dtos;
using Primeira_API.Models;

namespace Primeira_API.Controllers;

[ApiController]
[Route("cinema")]
public class CinemaController : ControllerBase
{
    private FilmesContext _context;
    private IMapper _imapper;

    public CinemaController(FilmesContext context, IMapper imapper)
    {
        _context = context;
        _imapper = imapper;
    }

    [HttpPost("create")]
    public IActionResult create(CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _imapper.Map<Cinema>(cinemaDto);
        _context.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(readbyid), new { id = cinema.id }, cinema);
    }

    [HttpGet("read")]
    public IEnumerable<ReadCinemaDto> read([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _imapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());
    }

    [HttpGet("readbyid/{id}")]
    public IActionResult readbyid(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinemas => cinemas.id == id);
        if(cinema == null)
        {
            return NotFound();
        }

        return Ok(_imapper.Map<ReadCinemaDto>(cinema));  
    }

    [HttpPut("update/{id}")]
    public IActionResult update(UpdateCinemaDto cinemaDto, int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinemas => cinemas.id == id);
        if (cinema == null)
        {
            return NotFound();
        }

        _imapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public IActionResult delete(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinemas => cinemas.id == id);
        if(cinema == null)
        {
            return NotFound();
        }

        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return Ok();
    }
}
