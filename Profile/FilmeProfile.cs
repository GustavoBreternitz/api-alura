namespace Primeira_API.Profile;
using AutoMapper;
using Primeira_API.Data.Dtos;
using Primeira_API.Models;

public class FilmeProfile : Profile
{
    public FilmeProfile() 
    { 
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<EditFilmeDto, Filme>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
