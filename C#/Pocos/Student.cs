using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Interfaces;

namespace Tutor_Database.Pocos
{
    public class Student : IPoco
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public long city_code { get; set; }
        public long phone_number { get; set; }


        public Student()
        {

        }
        public Student(string first_name, string last_name, string user_name, string password, string email, int age, long city_code, long phone_number)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.user_name = user_name;
            this.password = password;
            this.email = email;
            this.age = age;
            this.city_code = city_code;
            this.phone_number = phone_number;
        }
        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                id == student.id &&
                first_name == student.first_name &&
                last_name == student.last_name &&
                user_name == student.user_name &&
                password == student.password &&
                email == student.email &&
                age == student.age &&
                city_code == student.city_code &&
                phone_number == student.phone_number;
        }

        public override int GetHashCode()
        {
            return (int)this.id;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (ReferenceEquals(student1, null) && ReferenceEquals(student2, null))
            {
                return true;
            }
            if (ReferenceEquals(student1, null) || ReferenceEquals(student2, null))
            {
                return false;
            }
            if (student1.first_name == student2.first_name && student1.last_name == student2.last_name && student1.user_name == student2.user_name && student1.password == student2.password && student1.email == student2.email && student1.age == student2.age && student1.city_code == student2.city_code && student1.phone_number == student2.phone_number)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }
        public override string ToString()
        {
            return $"First name:{this.first_name}" + $" Last name: {this.last_name}";
        }
    }
}
