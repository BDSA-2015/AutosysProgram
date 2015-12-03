// AutoMaperConfiguratorStub.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using AutoMapper;

namespace ApplicationLogicTests.Mapping.Stub
{
    /// <summary>
    /// This stub is used to configure the mapping profile for auto
    /// mapper. 
    /// </summary>
    public class AutoMaperConfiguratorStub
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new MappingProfileStub());
            });
        }
    }
}