﻿using AutoMapper;
using Starting_Project.DTOs;
using Starting_Project.Models;


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
                cfg.CreateMap<Models.ApplicationForm, DTOs.ApplicationForm>().ReverseMap();
                cfg.CreateMap<Models.Education, DTOs.Education>().ReverseMap();
                cfg.CreateMap<Models.Experience, DTOs.Experience>().ReverseMap();
            });
            var mapper = config.CreateMapper();
        }
    }
}
