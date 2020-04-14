using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Interfaces;
using Tutor_Database.Pocos;
using Tutor_Database.RestApiHelper;

namespace Tutor_Database
{
    public static class HelperClass
    {
        static long studentID = 0;
        static long tutorID = 0;
        static RestApiAllData apiData;
        public static string connection = @"Data Source =DESKTOP-0NBGVN2\MSSQLSERVER01; Initial Catalog = Tutor; Integrated Security = True";
        public static long GetStudentIdByUserName(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("GetStudentIdByUserName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userName", student.user_name));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    studentID = (long)reader["Id"];
                }
                cmd.Connection.Close();
            }
            return studentID;
        }

        public static long GetTutorIdByUserName(Tutor tutor)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("GetTutorIdByUserName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userName", tutor.user_name));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    tutorID = (long)reader["Id"];
                }
                cmd.Connection.Close();
            }
            return tutorID;
        }

        public static bool IsUserExistInStudents(Student student)
        {

            long id = 0;
            using (SqlConnection conn = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand($"SELECT Id FROM STUDENTS WHERE User_name = @userName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", student.user_name));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    id = (long)reader["Id"];
                }
                cmd.Connection.Close();
            }
            if (id == 0)
                return false; // Student not exists in database.
            return true; // Student exists in database.
        }
        public static bool IsUserExistInTutors(Tutor tutor)
        {

            long id = 0;
            using (SqlConnection conn = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand($"SELECT Id FROM Tutor_tb WHERE User_name = @userName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@userName", tutor.user_name));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    id = (long)reader["Id"];
                }
                cmd.Connection.Close();
            }
            if (id == 0)
                return false; // Tutor not exists in database.
            return true; // Tutor exists in database.
        }
        public static long GetCityCodeByCityName(string cityName)
        {
            long cityId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Id FROM Cities_tb WHERE City_name=@cityName", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@cityName", cityName));
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        cityId = (long)reader["Id"];
                    }
                    cmd.Connection.Close();
                }

            }
            catch (Exception)
            {
                throw new Exception("EXCEPTION");
            }
            return cityId;
        }
        public static long GetProfessionCodeByName(string profession_name)
        {
            long professionCode = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT Id FROM Professions_tb WHERE Profession_name=@profession_name", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@profession_name", profession_name));
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        professionCode = (long)reader["Id"];
                    }
                    cmd.Connection.Close();
                }
                return professionCode;
            }
            catch (Exception)
            {
                throw new Exception("EXCEPTION");
            }
        }
        public static void InsertCitiesToDatabase()
        {
            apiData = new RestApiAllData();
            List<string> listOfCities = apiData.GetCities();
            using (SqlConnection conn = new SqlConnection(connection))
            {

                foreach (var city in listOfCities)
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO Cities_tb (City_name) VALUES (@city)", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

            }
        }
        public static void InsertProfessionsToDatabase()
        {
            apiData = new RestApiAllData();
            List<string> listOfProfessions = apiData.GetProfessions();
            using (SqlConnection conn = new SqlConnection(connection))
            {

                foreach (var city in listOfProfessions)
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO Professions_tb (Profession_name) VALUES (@profession)", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@profession", city));
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

            }
        }
    }
}
