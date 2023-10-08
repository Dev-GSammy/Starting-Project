using AutoMapper;
using Starting_Project.DTOs;
using Starting_Project.Models;


namespace Starting_Project.Mappers
{
    public class SkillsMapper
    {
        public SkillsMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Skills, SkillsDto>().ReverseMap();
                //cfg.CreateMap<Skills, Skills>();
            });
            var mapper = config.CreateMapper();
        }
    }
}
