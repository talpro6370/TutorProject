using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor_Database.Pocos;
using System.Data;
using Tutor_Database.Interfaces;
using System.Configuration;

namespace Tutor_Database.DAO
{
    public class StudentDAO : IStudentDAO
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        public StudentDAO()
        {

        }
        public bool Add(Student student)
        {
            try
            {
                if (!HelperClass.IsUserExistInStudents(student))
                {

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("AddStudent", conn);
                        cmd.Connection.Open();
                        cmd.Parameters.Add(new SqlParameter("@firstName", student.first_name));
                        cmd.Parameters.Add(new SqlParameter("@lastName", student.last_name));
                        cmd.Parameters.Add(new SqlParameter("@userName", student.user_name));
                        cmd.Parameters.Add(new SqlParameter("@password", student.password));
                        cmd.Parameters.Add(new SqlParameter("@email", student.email));
                        cmd.Parameters.Add(new SqlParameter("@age", student.age));
                        cmd.Parameters.Add(new SqlParameter("@city_code", student.city_code));
                        cmd.Parameters.Add(new SqlParameter("@phoneNumber", student.phone_number));
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    log.Info($"New student has been created: {student.ToString()}");
                    return true;
                }
                else
                {
                    log.Error($"Existing student is trying to create more accounts!: {student.ToString()}");
                    return false;
                }
            }

            catch (Exception e)
            {
                log.Error(e.Message.ToString());
                throw new Exception(e.Message);
            }

        }

        public void Remove(Student student)
        {
            long studentID = HelperClass.GetStudentIdByUserName(student);

            try
            {
                if (studentID != 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand($"DELETE FROM STUDENTS WHERE Id = {studentID}", conn);
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                else
                {
                    log.Error($"User tried to remove student:{student.ToString()}" + $"Cannot find the user.id: {studentID}");

                }
            }
            catch (Exception e)
            {
                log.Error(e.Message.ToString());
                throw new Exception(e.Message);
            }
            log.Info($"Student has been removed: {student.ToString()}");
        }

        public Student GetById(long id) // Dont forget to get city code before controll call this func.
        {
            Student student = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM STUDENTS WHERE Id = @id", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        student = new Student()
                        {
                            id = id,
                            first_name = (string)reader["First_name"],
                            last_name = (string)reader["Last_name"],
                            user_name = (string)reader["User_name"],
                            password = (string)reader["Password"],
                            email = (string)reader["Email"],
                            age = (int)reader["Age"],
                            city_code = (long)reader["City_code"],
                            phone_number = (long)reader["Phone_number"]
                        };
                    }
                    cmd.Connection.Close();
                }
                return student;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }

        }
        public Student GetStudentByUserName(string userName)
        {
            Student student = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM STUDENTS WHERE User_name = @userName", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@userName", userName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        student = new Student()
                        {
                            id = (long)reader["Id"],
                            first_name = (string)reader["First_name"],
                            last_name = (string)reader["Last_name"],
                            user_name = (string)reader["User_name"],
                            password = (string)reader["Password"],
                            email = (string)reader["Email"],
                            age = (int)reader["Age"],
                            city_code = (long)reader["City_code"],
                            phone_number = (long)reader["Phone_number"]
                        };
                    }
                    cmd.Connection.Close();
                }
                return student;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }


        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM STUDENTS", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        Student student = new Student()
                        {
                            id = (long)reader["Id"],
                            first_name = (string)reader["First_name"],
                            last_name = (string)reader["Last_name"],
                            user_name = (string)reader["User_name"],
                            password = (string)reader["Password"],
                            email = (string)reader["Email"],
                            age = (int)reader["Age"],
                            city_code = (long)reader["City_code"],
                            phone_number = (long)reader["Phone_number"]
                        };
                        students.Add(student);
                    }
                    cmd.Connection.Close();
                }
                return students;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }

        }

        public List<Tutor> SearchTutorByArea(string city)
        {
            long cityCode = HelperClass.GetCityCodeByCityName(city);
            List<Tutor> tutors = new List<Tutor>();
            Tutor tutor = null;
            try
            {
                if (cityCode != 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand($"SELECT * FROM Tutor_tb WHERE City_code = @cityCode", conn);
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@cityCode", cityCode));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read() == true)
                        {
                            tutor = new Tutor()
                            {
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
                }
                else
                {
                    log.Info($"City code invalid! User's input : {cityCode}");
                }
                log.Info($"User has been search tutors by city id : {cityCode}" + $" city name: {city}");
                return tutors;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }
        }

        public List<Tutor> SearchTutorByName(string tutorName, string tutorLastName)
        {
            List<Tutor> tutors = new List<Tutor>();
            Tutor tutor = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Tutor_tb WHERE (First_name =@tutorName and Last_name =@tutorLastName )", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@tutorName", tutorName));
                    cmd.Parameters.Add(new SqlParameter("@tutorLastName", tutorLastName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        tutor = new Tutor()
                        {
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
                log.Info($"User has been search tutors by name : {tutorName}" + $" {tutorLastName}");
                return tutors;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

        }

        public List<Tutor> SearchTutorByProf(string professionName)
        {
            long professionCode = HelperClass.GetCityCodeByCityName(professionName);
            // If the profession not found in professions table from database
            if (professionCode == 0)
            {
                return null;
            }
            List<Tutor> tutors = new List<Tutor>();
            Tutor tutor = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Tutor_tb WHERE  =@professionName", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@professionName", professionName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        tutor = new Tutor()
                        {
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
            catch (Exception ex)
            {
                throw ex; // Log4netTheExc..
            }
        }

        public void Update(Student student)
        {
            try
            {
                // NEED TO GET NEW CITY CODE FROM USER - HE KNOWS CITY NAME ONLY! CREATE NEW METHOD!!
                if (HelperClass.IsUserExistInStudents(student))
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("UpdateStudent", conn);
                        cmd.Connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@password", student.password));
                        cmd.Parameters.Add(new SqlParameter("@email", student.email));
                        cmd.Parameters.Add(new SqlParameter("@age", student.age));
                        cmd.Parameters.Add(new SqlParameter("@cityCode", student.city_code));
                        cmd.Parameters.Add(new SqlParameter("@phoneNumber", student.phone_number));
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
    }
}
