using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Pocos;

namespace Tutor_Database.Interfaces
{
    public interface ITutorDAO : IMain<Tutor>
    {

        Tutor GetTutorByUserName(string userName);
    }
}
