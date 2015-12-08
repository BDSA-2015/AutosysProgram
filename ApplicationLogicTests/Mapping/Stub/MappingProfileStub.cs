using AutoMapper;

namespace ApplicationLogicTests.Mapping.Stub
{
    /// <summary>
    /// This profile will be used for testing. It will map all the testing objects
    /// so automapper can be tested
    /// </summary>
    public class MappingProfileStub : Profile
    {

        protected override void Configure()
        {
            CreateMappings();
        }

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