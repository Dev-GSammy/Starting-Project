using Starting_Project.Controllers;
using Starting_Project.Controller;


public class Program
{
    public static async Task Main(string[] args)
    {
        await RunInstructionsAsync();
    }
    public static async Task RunInstructionsAsync()
    {
        ProgramsController programsController = new ProgramsController();
        ApplicationFormController applicationFormController = new ApplicationFormController();
        try
        {
            #region ProgramController Test
            //await programsController.InsertProgramsAsync(); //Uncomment and run any of the methods as you will
            //await programsController.GetProgramsAsync();
            //await programsController.GetProgramAsync("03be52db-3874-43bf-a5a9-1dd020ebb277");
            //await programsController.UpdateProgramAsync("07e0bf8e-afdb-4d8f-9a41-1b689131efc8");
            #endregion

            #region ApplicationForm Controller Test
            //await applicationFormController.InsertApplicationFormAsync(); //Uncomment and run any of the methods as you will
            //await applicationFormController.GetApplicationFormsAsync();
            //await applicationFormController.GetApplicationFormAsync("a177bdc4-cd7b-4bb9-a078-84d3a2a822a2");
            await applicationFormController.UpdateApplicationFormAsync("a177bdc4-cd7b-4bb9-a078-84d3a2a822a2");
            #endregion
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


