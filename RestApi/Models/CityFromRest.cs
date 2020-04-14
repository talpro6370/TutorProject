using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor_Database.RestApiHelper
{
    public class CityFromRest
    {
        public string english_name { get; set; }

        public string English_name
        {
            get { return english_name; }
            set { this.english_name = value; }
        }

    }
}
