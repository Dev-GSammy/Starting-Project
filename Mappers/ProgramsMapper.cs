using AutoMapper;
using Starting_Project.DTOs;
using StartingProjectDemo.DTOs;
using StartingProjectDemo.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Starting_Project.Mappers
{
    public class ProgramsMapper
    {
        public ProgramsMapper()
        {
            
        }
        public void CreateMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Programs, ProgramsDto>().ReverseMap();
                cfg.CreateMap<Skills, SkillsDto>().ReverseMap();
            });
            var mapper = config.CreateMapper();
        }
    }
}
