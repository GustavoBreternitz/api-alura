namespace Primeira_API.Profile;
using AutoMapper;
using Primeira_API.Data.Dtos;
using Primeira_API.Models;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Cinema>();
        CreateMap<UpdateEnderecoDto, Cinema>();
        CreateMap<Cinema, ReadEnderecoDto>();
    }
}
