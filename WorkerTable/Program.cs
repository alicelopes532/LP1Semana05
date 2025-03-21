using System;
using System.Reflection.Metadata;
using System.Text;
using Bogus;
using Spectre.Console;

namespace WorkerTable
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Randomizer.Seed = new Random(int.Parse(args[0]));
            var userIds = 3;
            Faker faker1 = new Faker("pt_PT");
            Faker faker2 = new Faker("pt_PT");
            Faker faker3 = new Faker("pt_PT");

            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
            .RuleFor(u => u.SomethingUnique, f => $"Value {f.UniqueIndex}")
            .RuleFor(u => u.CartId, f => Guid.NewGuid())
            .RuleFor(u => u.Job, (f, u) => f.Job(u.FirstName, u.LastName))

            Faker = faker1.Generate();
            Faker = faker2.Generate();
            Faker = faker3.Generate();

            //colunas
            var table = new table();
            table.AddColumn("ID");
            table.AddColumn(new TableColumn("Name").Centered());
            table.AddColumn(new TableColumn("Job").RightAligned());

            //linhas das colunas
            table.AddRow(faker1);
            table.AddRow(faker2);
            table.AddRow(faker3);

            AnsiConsole.Write(table);

        }
    }
}
