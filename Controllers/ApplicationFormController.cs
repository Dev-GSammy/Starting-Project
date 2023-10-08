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
        public ApplicationFormController()
        {
            
        }
        public ApplicationFormController(Data _data, Mapper _mapper)
        {
            data = _data;
            mapper = _mapper;
        }

        #region Insert Application Form
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
        #endregion

        #region Get Application Forms
        public async Task GetApplicationFormsAsync()
        {
            if (data.ApplicationForm != null)
            {
                var applicationform = await data.ApplicationForm.ToListAsync();
                Console.WriteLine("");
                //var programsDto = await data.Programs.ProjectTo<ProgramsDto>(mapper.ConfigurationProvider).ToListAsync();


                foreach (var a in applicationform)
                {
                    Console.WriteLine("First Name " + a.firstName);
                    Console.WriteLine("Last Name " + a.lastName);
                    Console.WriteLine("Email " + a.Email);
                    Console.WriteLine("Phone Number " + a.phoneNumber);
                    Console.WriteLine("ID Number " + a.idNumber);
                    Console.WriteLine("--------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine("data.ApplicationForm is null");
            }
        }
        #endregion 

        #region Get an Application Form
        public async Task GetApplicationFormAsync(string Id)
        {
            if (data.ApplicationForm != null)
            {
                var applicationform = await data.ApplicationForm
                    .FirstOrDefaultAsync(e => e.Id == Id);
                var applicationFormDto = mapper.Map<DTOs.ApplicationForm>(applicationform);
                Console.WriteLine("");
                Console.WriteLine("First Name : " + applicationform?.firstName);
                Console.WriteLine("Last Name : " + applicationform?.lastName);
                Console.WriteLine("ID Number : " + applicationform?.idNumber);
            }
        }
        #endregion

        #region Update Application Form
        public async Task UpdateApplicationFormAsync(string Id)
        {
            if (data.ApplicationForm != null)
            {
                var applicationForm = await data.ApplicationForm
                    .FirstOrDefaultAsync(e => e.Id == Id);

                if (applicationForm != null)
                {
                    applicationForm.Email = "QuiteATask@yahoo.com";
                    applicationForm.nationality = "Ugandan";

                    await data.SaveChangesAsync();

                    Console.WriteLine("\nApplication Form has been updated.\n");
                }
            }
        }
        #endregion
    }
}
