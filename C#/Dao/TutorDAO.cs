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

namespace Tutor_Database.DAO
{
    public class TutorDAO : ITutorDAO
    {
        public bool Add(Tutor tutor)
        {
            try
            {
                if (!HelperClass.IsUserExistInTutors(tutor))
                {
                    using (SqlConnection conn = new SqlConnection(HelperClass.connection))
                    {
                        SqlCommand cmd = new SqlCommand("AddTutor", conn);
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@firstName", tutor.first_name));
                        cmd.Parameters.Add(new SqlParameter("@lastName", tutor.last_name));
                        cmd.Parameters.Add(new SqlParameter("@userName", tutor.user_name));
                        cmd.Parameters.Add(new SqlParameter("@password", tutor.password));
                        cmd.Parameters.Add(new SqlParameter("@email", tutor.email));
                        cmd.Parameters.Add(new SqlParameter("@city_code", tutor.city_code));
                        cmd.Parameters.Add(new SqlParameter("@phoneNumber", tutor.phone_number));
                        cmd.Parameters.Add(new SqlParameter("@professionCode", tutor.professsion_code));
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Tutor> GetAll()
        {
            List<Tutor> tutors = new List<Tutor>();
            try
            {
                using (SqlConnection conn = new SqlConnection(HelperClass.connection))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Tutor_tb", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        Tutor tutor = new Tutor()
                        {
                            id = (long)reader["Id"],
                            first_name = (string)reader["First_name"],
                            last_name = (string)reader["Last_name"],
                            user_name = (string)reader["User_name"],
                            password = (string)reader["Password"],
                            email = (string)reader["Email"],
                            city_code = (long)reader["City_code"],
                            phone_number = (long)reader["Phone_number"],
                            professsion_code = (long)reader["Profession_code"]
                        };
                        tutors.Add(tutor);
                    }
                    cmd.Connection.Close();
                }
                return tutors;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public Tutor GetById(long id)
        {
            Tutor tutor = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(HelperClass.connection))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Tutor_tb WHERE Id = @id", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        tutor = new Tutor()
                        {
                            id = id,
                            first_name = (string)reader["First_name"],
                            last_name = (string)reader["Last_name"],
                            user_name = (string)reader["User_name"],
                            password = (string)reader["Password"],
                            email = (string)reader["Email"],
                            city_code = (long)reader["City_code"],
                            phone_number = (long)reader["Phone_number"],
                            professsion_code = (long)reader["Profession_code"]
                        };
                    }
                    cmd.Connection.Close();
                }
                return tutor;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        public void Remove(Tutor tutor)
        {
            long tutorID = HelperClass.GetTutorIdByUserName(tutor);

            try
            {
                if (tutorID != 0)
                {
                    using (SqlConnection conn = new SqlConnection(HelperClass.connection))
                    {
                        SqlCommand cmd = new SqlCommand($"DELETE FROM STUDENTS WHERE Id = {tutorID}", conn);
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                else
                {
                    Console.WriteLine("USER IS NOT EXIST!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("USER IS NOT EXIST!", e.InnerException);
            }
        }

        public void Update(Tutor tutor)
        {
            try
            {
                // NEED TO GET NEW CITY CODE FROM USER - HE KNOWS CITY NAME ONLY! CREATE NEW METHOD!!
                if (HelperClass.IsUserExistInTutors(tutor))
                {
                    using (SqlConnection conn = new SqlConnection(HelperClass.connection))
                    {
                        SqlCommand cmd = new SqlCommand("UpdateTutor", conn);
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@password", tutor.password));
                        cmd.Parameters.Add(new SqlParameter("@email", tutor.email));
                        cmd.Parameters.Add(new SqlParameter("@cityCode", tutor.city_code));
                        cmd.Parameters.Add(new SqlParameter("@phoneNumber", tutor.phone_number));
                        cmd.Parameters.Add(new SqlParameter("@professionCode", tutor.professsion_code));

                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                else
                {
                    Console.WriteLine("USER DOES NOT EXIST!");
                }
            }
            catch (Exception e)
            {

                throw new Exception("EXCEPTION", e.InnerException);
            }
        }

        public Tutor GetTutorByUserName(string userName)
        {
            try
            {
                Tutor tutor = null;
                using (SqlConnection conn = new SqlConnection(HelperClass.connection))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Tutor_tb WHERE User_name = @userName", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@userName", userName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        tutor = new Tutor()
                        {
                            id = (long)reader["Id"],
                            first_name = (string)reader["First_name"],
                            last_name = (string)reader["Last_name"],
                            user_name = (string)reader["User_name"],
                            password = (string)reader["Password"],
                            email = (string)reader["Email"],
                            city_code = (long)reader["City_code"],
                            phone_number = (long)reader["Phone_number"],
                            professsion_code = (long)reader["Profession_code"]
                        };
                    }
                    cmd.Connection.Close();
                }
                return tutor;
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }
    }
}
