using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MachineCartSystem.Entity.Model
{
    public class MachineCartSystemDbContextFactory : IDesignTimeDbContextFactory<MachineCartSystemDbContext>
    {
        public MachineCartSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MachineCartSystemDbContext>();
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .AddJsonFile($"appsettings.{envName}.json", true)
                 .Build();
            var connStr="";//= configuration.GetValue<string>("DbConfiguration:ConnectionString");

            builder.UseSqlServer(connStr);
            return new MachineCartSystemDbContext(builder.Options);
        }
    }
}
