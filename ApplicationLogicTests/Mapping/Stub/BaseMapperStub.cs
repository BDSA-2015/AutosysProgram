using ApplicationLogics.StorageFasade.Mapper;

namespace ApplicationLogicTests.Mapping.Stub
{
    public class BaseMapperStub :IMap
    {
        public void CreateMappings()
        {
            //Mapping DTO to object with same properties
            AutoMapper.Mapper.CreateMap<ObjectDto, ObjectSameOneProperty>();


            //Mapping DTO to object with many properties
            AutoMapper.Mapper.CreateMap<ObjectDto, ObjectManyProperties>()
                .ForMember(target => target.FirstName,
                           opt => opt.MapFrom(sourceDto => sourceDto.Name.Split(' ')[0]))
                .ForMember(target => target.LastName,
                           opt => opt.MapFrom(sourceDto => sourceDto.Name.Split(' ')[1])); 

            //Mapping DTO to object with different property name.
            AutoMapper.Mapper.CreateMap<ObjectDto, ObjectDifferentProperty>()
                .ForMember( target => target.FullName, 
                            opt => opt.MapFrom(sourceDto => sourceDto.Name));
        }
    }
}