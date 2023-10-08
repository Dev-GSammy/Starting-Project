using Starting_Project.Persistence;
using AutoMapper;
using DTOs =Starting_Project.DTOs;
using Models = Starting_Project.Models;
using Microsoft.EntityFrameworkCore;
using Starting_Project.Mappers;
using Starting_Project.Models;

namespace Starting_Project.Controllers
{
    public class ApplicationFormController
    {
        private readonly Data data;
        private readonly Mapper mapper;
        public ApplicationFormController(Data _data, Mapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        public async Task InsertApplicationFormAsync()
        {
            var applicationForm1 = new Models.ApplicationForm()
            {
                Id = Guid.NewGuid().ToString(),
                image = "",
                firstName = "Samuel",
                lastName = "Handsome",
                Email = "welcomehere@gmail.com",
                phoneNumber = "+1 234 786 899",
                idNumber = "67-dw",
                Gender = "Male"
            };

            data.ApplicationForm?.Add(applicationForm1);
            await data.SaveChangesAsync();
            Console.WriteLine("Application records inserted successfully...");
        }
    }
}
