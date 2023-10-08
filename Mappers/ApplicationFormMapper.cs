using AutoMapper;
using dto = Starting_Project.DTOs;
using model = Starting_Project.Models;

namespace Starting_Project.Mappers
{
    public  class ApplicationFormMapper
    {
        public void CreateMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<model.ApplicationForm, dto.ApplicationForm>().ReverseMap();
                cfg.CreateMap<model.Experience, dto.Experience>().ReverseMap();
                cfg.CreateMap<model.Education, dto.Education>().ReverseMap();
            });
            var mapper = config.CreateMapper();
        }
    }
}
