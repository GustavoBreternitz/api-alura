using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Primeira_API.Data;
using Primeira_API.Data.Dtos;
using Primeira_API.Models;

namespace Primeira_API.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : ControllerBase
    {
        private FilmesContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmesContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        [HttpPost("/create")]
        public IActionResult create(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(readbyid), new { id = endereco.id }, endereco);
        }

        [HttpGet("readbyid/{id}")]
        public IActionResult readbyid(int id)
        {
            var endereco = _context.Endereco.FirstOrDefault(enderecos => enderecos.id == id);  
            if(endereco == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadEnderecoDto>(endereco));    
        }

        [HttpGet("read")]
        public IEnumerable<ReadEnderecoDto> read([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Endereco.Skip(skip).Take(take).ToList());
        }

        [HttpPut("update/{id}")]
        public IActionResult update(int id, UpdateEnderecoDto enderecoDto)
        {
            var enderecos = _context.Endereco.FirstOrDefault(endereco => endereco.id == id);
            if(enderecos == null)
            {
                return BadRequest();
            }

            _mapper.Map(enderecoDto, enderecos);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult delete(int id)
        {
            var endereco = _context.Endereco.FirstOrDefault(enderecos => enderecos.id == id);
            if(endereco == null)
            {
                return BadRequest();
            }

            _context.Endereco.Remove(endereco);
            _context.SaveChanges();
            return Ok();
        }
    }
}
