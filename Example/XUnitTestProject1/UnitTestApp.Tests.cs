using MySQLApp;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Xunit;
using Example;




namespace UnitTestApp.Tests
{
    public class ConnectionTest
    {

        [Fact]
        public void TestConnection()
        {
            Assert.Equal(0, Example.Program.Connection());
        }

    }

    public class CRUDTests
    {
        [Fact]
        public void DeleteTestetTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0,Example.Program.DeleteTester(options, 12));
        }

        [Fact]
        public void InsertTestetTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0, Example.Program.InsertTester(options, "NewTester", "test.jpg"));
        }

        [Fact]
        public void UpdateTestetTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0, Example.Program.UpdateTester(options, 1, "UpdateTester"));
        }

        [Fact]
        public void UpdateFileTest()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettingstest.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("TestConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Assert.Equal(0, Example.Program.UpdateFile(options, 1, "test.jpg"));
        }
    }
}
