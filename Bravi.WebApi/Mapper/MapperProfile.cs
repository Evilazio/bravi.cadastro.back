using AutoMapper;
using Bravi.Data.Database.Models;
using Bravi.WebApi.DTO;

namespace Bravi.WebApi.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Pessoa, PessoaDTO>();
            CreateMap<PessoaDTO, Pessoa>();
            
            CreateMap<Contato, ContatoDTO>();
            CreateMap<ContatoDTO, Contato>();
            
            CreateMap<ContatoTipo, ContatoTipoDTO>();
            CreateMap<ContatoTipoDTO, ContatoTipo>();



        }
    }
}
