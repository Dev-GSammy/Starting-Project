using System;
using Starting_Project.Controllers;
using Microsoft.EntityFrameworkCore;
using Starting_Project.Mappers;
using Starting_Project.Controller;
using Starting_Project.Persistence;
using AutoMapper;

public class Program
{
    public static async Task Main(string[] args)
    {
        await RunInstructionsAsync();
    }
    public static async Task RunInstructionsAsync()
    {
        ProgramsController programsController = new ProgramsController();
        #region ProgramController Test
        //await programsController.InsertProgramsAsync(); //Uncomment and run any of the methods as you will
        //await programsController.GetProgramsAsync();
        await programsController.GetProgramAsync("03be52db-3874-43bf-a5a9-1dd020ebb277");
        //await programsController.UpdateProgramAsync("07e0bf8e-afdb-4d8f-9a41-1b689131efc8");
        #endregion


    }
}


