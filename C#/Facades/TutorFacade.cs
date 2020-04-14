using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.DAO;
using Tutor_Database.Pocos;

namespace Tutor_Database.Facades
{
    public class TutorFacade : FacadeBase
    {
        public bool AddTutor(Tutor tutor)
        {
            _tutorDAO = new TutorDAO();
            return _tutorDAO.Add(tutor);
        }
        public List<Tutor> GetAll()
        {
            _tutorDAO = new TutorDAO();
            return _tutorDAO.GetAll();
        }
        public Tutor GetById(long id)
        {
            _tutorDAO = new TutorDAO();
            return _tutorDAO.GetById(id);
        }
        public Tutor GetTutorByUserName(string userName)
        {
            _tutorDAO = new TutorDAO();
            return _tutorDAO.GetTutorByUserName(userName);
        }
        public void UpdateTutor(Tutor tutor)
        {
            _tutorDAO = new TutorDAO();
            _tutorDAO.Update(tutor);
        }
        public void RemoveTutor(Tutor tutor)
        {
            _tutorDAO = new TutorDAO();
            _tutorDAO.Remove(tutor);
        }
    }
}
