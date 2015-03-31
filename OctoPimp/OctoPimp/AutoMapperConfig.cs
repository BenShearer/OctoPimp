using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Octopus.Client.Model;

namespace OctoPimp
{
    public class AutoMapperConfig
    {

        public static void ConfigureMappings() {
            Mapper.CreateMap<LibraryVariableSetResource, OctoVariableSet_ViewModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name));
        }
    }
}
