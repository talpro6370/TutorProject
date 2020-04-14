using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.DAO;
using Tutor_Database.Pocos;

namespace Tutor_Database.Interfaces
{
    public interface IStudentDAO : IMain<Student>
    {
        List<Tutor> SearchTutorByName(string tutorName, string tutorLastName);
        List<Tutor> SearchTutorByProf(string professionName);
        List<Tutor> SearchTutorByArea(string city);
        Student GetStudentByUserName(string userName);
    }
}
