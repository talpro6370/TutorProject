using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Interfaces;

namespace Tutor_Database.Pocos
{
    public class City : IPoco
    {
        private long id { get; set; }
        private string city_name { get; set; }

        public City(long id, string city_name)
        {
            this.id = id;
            this.city_name = city_name;
        }
    }
}
