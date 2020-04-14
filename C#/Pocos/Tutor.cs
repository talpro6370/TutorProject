using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Interfaces;

namespace Tutor_Database.Pocos
{
    public class Tutor : IPoco
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public long city_code { get; set; }
        public long phone_number { get; set; }
        public long id { get; set; }
        public long professsion_code { get; set; }

        public Tutor()
        {

        }
        public Tutor(string first_name, string last_name, string user_name, string password, string email, long city_code, long phone_number, long professsion_code)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.user_name = user_name;
            this.password = password;
            this.email = email;
            this.city_code = city_code;
            this.phone_number = phone_number;
            this.professsion_code = professsion_code;
        }
        public override bool Equals(object obj)
        {
            var tutor = obj as Tutor;
            return tutor != null &&
                id == tutor.id &&
                first_name == tutor.first_name &&
                last_name == tutor.last_name &&
                user_name == tutor.user_name &&
                password == tutor.password &&
                email == tutor.email &&
                city_code == tutor.city_code &&
                phone_number == tutor.phone_number &&
                professsion_code == tutor.professsion_code;

        }

        public override int GetHashCode()
        {
            return (int)this.id;
        }

        public static bool operator ==(Tutor tutor1, Tutor tutor2)
        {
            if (ReferenceEquals(tutor1, null) && ReferenceEquals(tutor2, null))
            {
                return true;
            }
            if (ReferenceEquals(tutor1, null) || ReferenceEquals(tutor2, null))
            {
                return false;
            }
            if (tutor1.first_name == tutor2.first_name && tutor1.last_name == tutor2.last_name && tutor1.user_name == tutor2.user_name && tutor1.password == tutor2.password && tutor1.email == tutor2.email && tutor1.city_code == tutor2.city_code && tutor1.phone_number == tutor2.phone_number && tutor1.professsion_code == tutor2.professsion_code)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Tutor tutor1, Tutor tutor2)
        {
            return !(tutor1 == tutor2);
        }
    }
}
