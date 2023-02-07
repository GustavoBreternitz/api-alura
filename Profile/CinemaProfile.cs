namespace Primeira_API.Profile;
using AutoMapper;
using Primeira_API.Data.Dtos;
using Primeira_API.Models;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
    }
}
