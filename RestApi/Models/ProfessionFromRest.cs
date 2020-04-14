using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor_Database.RestApiHelper
{
    public class ProfessionFromRest
    {
        public string guardianSubjectGroup { get; set; }

        public string GuardianSubjectGroup
        {
            get { return guardianSubjectGroup; }
            set { this.guardianSubjectGroup = value; }
        }
    }
}