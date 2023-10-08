using AutoMapper;
using StartingProjectDemo.DTOs;
using StartingProjectDemo.Models;
using System.Runtime.CompilerServices;

namespace Starting_Project.Mappers
{
    public class Mappers
    {
        public Mappers()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Programs, ProgramsDto>();
                //cfg.CreateMap<Skills, Skills>();
            });
            var mapper = config.CreateMapper();
        }
    }
}
