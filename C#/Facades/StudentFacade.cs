using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.DAO;
using Tutor_Database.Interfaces;
using Tutor_Database.Pocos;

namespace Tutor_Database.Facades
{
    public class StudentFacade : FacadeBase
    {
        public void AddStudent(Student student)
        {
            _studentDAO = new StudentDAO();
            _studentDAO.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentDAO = new StudentDAO();
            _studentDAO.Remove(student);
        }

        public List<Tutor> SearchTutorByArea(string city)
        {
            _studentDAO = new StudentDAO();
            return _studentDAO.SearchTutorByArea(city);
        }

        public List<Tutor> SearchTutorByName(string tutorName, string lastName)
        {
            _studentDAO = new StudentDAO();
            return _studentDAO.SearchTutorByName(tutorName, lastName);
        }

        public List<Tutor> SearchTutorByProf(string professionName)
        {
            _studentDAO = new StudentDAO();
            return _studentDAO.SearchTutorByProf(professionName);
        }

        public void UpdateStudent(Student student)
        {
            _studentDAO = new StudentDAO();
            _studentDAO.Update(student);
        }
        public List<Student> GetAll()
        {
            _studentDAO = new StudentDAO();
            return _studentDAO.GetAll();
        }
        public Student GetById(long id)
        {
            _studentDAO = new StudentDAO();
            return _studentDAO.GetById(id);
        }
        public Student GetByUserName(string userName)
        {
            _studentDAO = new StudentDAO();
            return _studentDAO.GetStudentByUserName(userName);
        }
    }
}
