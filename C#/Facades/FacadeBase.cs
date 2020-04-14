using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Interfaces;

namespace Tutor_Database.Facades
{
    public abstract class FacadeBase
    {
        protected IStudentDAO _studentDAO;
        protected ITutorDAO _tutorDAO;
    }
}
