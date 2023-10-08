using StartingProjectDemo.Persistence;
using StartingProjectDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos.Linq;
using System;


namespace StartingProjectDemo.Controller
{
    public class ProgramsController
    {
        private readonly Data data;
        public ProgramsController()
        {
            data = new Data();
        }
        public ProgramsController(Data _data)
        {
            data = _data;
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

                foreach (var p in programs)
                {
                    Console.WriteLine("Program Id : " + p.Id);
                    Console.WriteLine("Program Title : " + p.Title);
                    Console.WriteLine("Program Summary : " + p.Summary);
                    Console.WriteLine("Skills : " + p.Skills);
                    Console.WriteLine("Program Benefits : " + p.Benefits);
                    Console.WriteLine("Application Criteria : " + p.applicationCriteria);
                    Console.WriteLine("Program Type : " + p.programType);
                    Console.WriteLine("Program Start Date : " + p.programStartDate);
                    Console.WriteLine("Application Open Date : " + p.applicationOpenDate);
                    Console.WriteLine("Application Close Date : " + p.applicationCloseDate);
                    Console.WriteLine("Program Duration : " + p.Duration);
                    Console.WriteLine("Program Location : " + p.programLocation);
                    Console.WriteLine("Minimum Qualification : " + p.minQualification);
                    Console.WriteLine("Maximum Applications : " + p.maxApplications);

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

                Console.WriteLine("");

                Console.WriteLine("Program Title : " + program?.Title);
                Console.WriteLine("Program Summary : " + program?.Summary);
                Console.WriteLine("Program Description : " + program?.programDescription);
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