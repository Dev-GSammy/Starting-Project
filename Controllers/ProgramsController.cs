﻿using StartingProjectDemo.Persistence;
using AutoMapper;
using StartingProjectDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos.Linq;
using System;
using StartingProjectDemo.DTOs;
using AutoMapper.QueryableExtensions;


namespace StartingProjectDemo.Controller
{
    public class ProgramsController
    {
        private readonly Data data;
        private readonly Mapper mapper;
        public ProgramsController()
        {
            data = new Data();
        }
        public ProgramsController(Data _data, Mapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        #region Insert Programs
        public async Task InsertProgramsAsync()
        {
            var programs1 = new Programs()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "First Program",
                programDescription = "This is my first Program Description",
                Skills = new List<Skills>()
                {
                    new Skills()
                    {
                        skill = "Software Engineering"
                    },
                    new Skills()
                    {
                        skill = "Computer Technician"
                    }
                },
                programType = "Virtual",
                applicationOpenDate = DateTime.Now.AddDays(20).Date,
                applicationCloseDate = DateTime.Now.AddMonths(5).Date,
                programLocation = "London, UK"
            };
            var programs2 = new Programs()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Second Program",
                programDescription = "This is my second program Description",
                Skills = new List<Skills>()
                {
                    new Skills()
                    {
                        skill = "Food Scientist"
                    },
                    new Skills()
                    {
                        skill = "Database Engineer"
                    }
                },
                programType = "Full Time",
                applicationOpenDate = DateTime.Now.AddDays(22).Date,
                applicationCloseDate = DateTime.Now.AddMonths(7).Date,
                programLocation = "Illinois, USA"
            };
            data.Programs?.Add(programs1);
            data.Programs?.Add(programs2);
            await data.SaveChangesAsync();
            Console.WriteLine("Program records inserted successfully...");
        }
        #endregion

        #region Get Programs
        public async Task GetPrograms()
        {


            if (data.Programs != null)
            {
                var programs = await data.Programs.ToListAsync();
                Console.WriteLine("");
                var programsDto = await data.Programs.ProjectTo<ProgramsDto>(mapper.ConfigurationProvider).ToListAsync();

                foreach (var p in programsDto)
                {
                    Console.WriteLine("Program Id : " + p.Id);
                    Console.WriteLine("Program Title : " + p.Title);
                    Console.WriteLine("Program Summary : " + p.Summary);
                    Console.WriteLine("Skills : " + p.Skills);
                    Console.WriteLine("Program Type : " + p.programType);
                    Console.WriteLine("Program Start Date : " + p.programStartDate);
                    Console.WriteLine("Program Duration : " + p.Duration);
                    Console.WriteLine("Program Location : " + p.programLocation);
                    Console.WriteLine("--------------------------------\n");
                }
            }
        }
        #endregion

        #region Get a Program
        public async Task GetProgram(string Id)
        {
            if (data.Programs != null)
            {
                var program = await data.Programs
                    .FirstOrDefaultAsync(e => e.Id == Id);
                var programsDto = mapper.Map<ProgramsDto>(program);
                Console.WriteLine("");

                Console.WriteLine("Program Title : " + programsDto?.Title);
                Console.WriteLine("Program Summary : " + programsDto?.Summary);
                Console.WriteLine("Program Description : " + programsDto?.programDescription);
                Console.WriteLine("--------------------------------\n");
            }
        }
        #endregion

        #region Update a program
        public async Task UpdateProgram(string Id)
        {
            if (data.Programs != null)
            {
                var program = await data.Programs
                    .FirstOrDefaultAsync(e => e.Id == Id);

                if (program != null)
                {
                    program.Title = "Updated Title";
                    program.Summary = "This is an updated program Summary";

                    await data.SaveChangesAsync();

                    Console.WriteLine("\nProgram has been updated.\n");
                }
            }
        }
        #endregion
    }
}