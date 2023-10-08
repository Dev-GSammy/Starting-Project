using System;
using StartingProjectDemo.Controller;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private readonly ProgramsController programsController;
    public Program(ProgramsController _programsController)
    {
        programsController = _programsController;

    }
    public async Task RunInstructionsAsync()
    {
        await programsController.InsertProgramsAsync(); //Uncomment and run any of the methods as you will
        //await programsController.GetPrograms();
        //await programsController.GetProgram("07e0bf8e-afdb-4d8f-9a41-1b689131efc8");
        //await programsController.UpdateProgram("07e0bf8e-afdb-4d8f-9a41-1b689131efc8");
    }
    static async Task Main()
    {
        var programsController = new ProgramsController(); //I created an instance of the ProgramsController
        var program = new Program(programsController); // I created an instance of the Program class
        await program.RunInstructionsAsync();
    }
}


