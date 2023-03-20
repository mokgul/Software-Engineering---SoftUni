namespace SoftJail;

using System;
using System.IO;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Data;

public class StartUp
{
    public static void Main(string[] args)
    {
        var context = new SoftJailDbContext();

        ResetDatabase(context, shouldDropDatabase: false);

        var projectDir = GetProjectDirectory();

        ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
        ExportEntities(context, projectDir + @"ExportResults/");

        using (var transaction = context.Database.BeginTransaction())
        {
            transaction.Rollback();
        }
    }

    private static void ImportEntities(SoftJailDbContext context, string baseDir, string exportDir)
    {
        var departmentsCells =
            DataProcessor.Deserializer.ImportDepartmentsCells(context,
                File.ReadAllText(baseDir + "ImportDepartmentsCells.json"));
        PrintAndExportEntityToFile(departmentsCells, exportDir + "ImportDepartmentsCells.txt");

        var prisonersMails =
            DataProcessor.Deserializer.ImportPrisonersMails(context,
                File.ReadAllText(baseDir + "ImportPrisonersMails.json"));
        PrintAndExportEntityToFile(prisonersMails, exportDir + "ImportPrisonersMails.txt");

        var officersPrisoners = DataProcessor.Deserializer.ImportOfficersPrisoners(context, File.ReadAllText(baseDir + "ImportOfficersPrisoners.xml"));
        PrintAndExportEntityToFile(officersPrisoners, exportDir + "ImportOfficersPrisoners.txt");
    }

    private static void ExportEntities(SoftJailDbContext context, string exportDir)
    {
        var jsonOutput = DataProcessor.Serializer.ExportPrisonersByCells(context, new[] { 1, 5, 7, 3 });
        Console.WriteLine(jsonOutput);
        File.WriteAllText(exportDir + "PrisonersByCells.json", jsonOutput);

        var xmlOutput = DataProcessor.Serializer.ExportPrisonersInbox(context, "Melanie Simonich,Diana Ebbs,Binni Cornhill");
        Console.WriteLine(xmlOutput);
        File.WriteAllText(exportDir + "PrisonersInbox.xml", xmlOutput);
    }
    private static void ResetDatabase(SoftJailDbContext context, bool shouldDropDatabase = false)
    {
        if (shouldDropDatabase)
        {
            context.Database.EnsureDeleted();
        }

        if (context.Database.EnsureCreated())
        {
            return;
        }

        var disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
        context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

        var deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
        context.Database.ExecuteSqlRaw(deleteRowsQuery);

        var enableIntegrityChecksQuery =
            "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
        context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

        var reseedQuery =
            "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
        context.Database.ExecuteSqlRaw(reseedQuery);
    }

    private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
    {
        Console.WriteLine(entityOutput);
        File.WriteAllText(outputPath, entityOutput.TrimEnd());
    }

    private static string GetProjectDirectory()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var directoryName = Path.GetFileName(currentDirectory);
        var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

        return relativePath;
    }
}
