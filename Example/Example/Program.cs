using MySQLApp;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;

namespace Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Connection();
            //UpdateTesterById(options, 1, "newName");
            //InsertTester(options, "NewTester");
            //DeleteTesterById(options, 18);
            

            Console.Read();
        }



        public static int DeleteTesterById(DbContextOptions<ApplicationContext> options, int id)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Tester tester = db.Tester.Find(id);
                if (tester != null)
                {
                    db.Tester.Remove(tester);
                    db.SaveChanges();
                    Console.WriteLine("Пользователь удалён");
                }
                else {
                    Console.WriteLine("Пользователя с таким id не существует");
                }
              
            }
            return 0;
        }

        public static int InsertTester(DbContextOptions<ApplicationContext> options, string Name)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Tester tester = new Tester { name_tester = Name };
                db.Tester.Add(tester);
                db.SaveChanges();
                Console.WriteLine("Пользователь добавлен");
               
            }
            return 0;
        }

        public static int UpdateTesterById(DbContextOptions<ApplicationContext> options, int id, string NewName)
        {
            
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Tester tester = db.Tester.Find(id);
                if (tester != null)
                {

                    tester.name_tester = NewName;
                    db.SaveChanges();
                    Console.WriteLine("Имя пользователя изменено");

                }
                else {
                    Console.WriteLine("Пользователя с таким id не существует");
                }
            }
            return 0;


        }


        //Подключение к БД
        public static int Connection()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;

            using (ApplicationContext db = new ApplicationContext(options)) {
               return 0;
            }


                

        }
    }
}
