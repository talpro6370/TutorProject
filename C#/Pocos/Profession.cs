using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Interfaces;

namespace Tutor_Database.Pocos
{
    public class Profession : IPoco
    {
        private long id { get; set; }
        private string profession_name { get; set; }

        public Profession(long id, string profession_name)
        {
            this.id = id;
            this.profession_name = profession_name;
        }
    }
}
