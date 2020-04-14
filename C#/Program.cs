using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.DAO;
using Tutor_Database.Exceptions;
using Tutor_Database.Pocos;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Tutor_Database
{
    class Program
    {

        static void Main(string[] args)
        {
            //HelperClass.InsertProfessionsToDatabase();
            //HelperClass.InsertCitiesToDatabase();
            StudentDAO stud = new StudentDAO();
            Student student = new Student("Itay", "harr", "3f3aa", "asf22f", "Itaykf@walla.com", 24, 11186, 0502255484);
            stud.Add(student);
            
            //stud.Remove(student);

        }
    }
}
