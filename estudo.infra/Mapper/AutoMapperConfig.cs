using AutoMapper;
using estudo.domain.DTO_s;
using estudo.domain.Entities;

namespace estudo.infra.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteEntity, ClienteOutputModel>().ReverseMap();
        }
    }
}
