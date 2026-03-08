using AutoMapper;
using PersonelYonetim.Personels;

namespace PersonelYonetim;

public class PersonelYonetimApplicationAutoMapperProfile : Profile
{
    public PersonelYonetimApplicationAutoMapperProfile()
    {
        CreateMap<Personel, PersonelDto>();
        CreateMap<CreateUpdatePersonelDto, Personel>();
    }
}
