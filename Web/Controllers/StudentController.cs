using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Tutor_Database;
using Tutor_Database.Facades;
using Tutor_Database.Pocos;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[Authorize]
    public class StudentController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public StudentFacade studentFcd = new StudentFacade();
        public TutorFacade tutorFcd = new TutorFacade();

        [ResponseType(typeof(List<Student>))]
        [Route("api/Students/AllStudents")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Student> students = new List<Student>();
                students = studentFcd.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                log.Error($"{ex.Message}");
                throw ex;
            }
        }


        [ResponseType(typeof(Student))]
        [Route("api/Students/student")]
        [HttpGet]
        public IHttpActionResult GetStudentByUserName(string userName)
        {
            try
            {
                Student student = new Student();
                student = studentFcd.GetByUserName(userName);
                if (student == null)
                    return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                log.Error($"{ex.Message}");
                throw ex;
            }
        }

        [ResponseType(typeof(Student))]
        [Route("api/Students/studentById")]
        [HttpGet]
        public IHttpActionResult GetStudentByById(long id)
        {
            try
            {
                Student student = new Student();
                student = studentFcd.GetById(id);
                if (student == null)
                    return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                log.Error($"{ex.Message}");
                throw ex;
            }
        }

        [HttpPost]
        [Route("api/CreateNewStudent")]
        public IHttpActionResult CreateNewStudent(StudentDets studentDetsFromWeb)
        {
            //  Cities will be ordered in a "drop-down" list - the user will choose from there.
            //  Then city-code will be brought by this func:
            long city_code_return = HelperClass.GetCityCodeByCityName(studentDetsFromWeb.city);
            Student student = new Student()
            {
                first_name = studentDetsFromWeb.first_name,
                last_name = studentDetsFromWeb.last_name,
                user_name = studentDetsFromWeb.user_name,
                password = studentDetsFromWeb.password,
                email = studentDetsFromWeb.email,
                age = studentDetsFromWeb.age,
                city_code = city_code_return,
                phone_number = studentDetsFromWeb.phone_number
            };

            if (student != null)
            {
                try
                {
                    studentFcd.AddStudent(student);
                    log.Info($"New student has been created in database: {student.first_name}" + $"{student.last_name}");
                    return Ok("Student successfully created!");
                }
                catch (Exception ex)
                {
                    log.Error($"Exception has been thrown: {ex.Message}");
                    throw ex;
                }
            }

            log.Error($"Server issues: {BadRequest().Request.Content}");
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Student/Details-Update")]
        public IHttpActionResult Update(StudentDets student)
        {
            try
            {
                Student newStudent = new Student()
                {
                    first_name = student.first_name,
                    last_name = student.last_name,
                    user_name = student.user_name,
                    password = student.password,
                    email = student.email,
                    age = student.age,
                    city_code = HelperClass.GetCityCodeByCityName(student.city),
                    phone_number = student.phone_number
                };

                studentFcd.UpdateStudent(newStudent);
                log.Info($"Student updated his details: {student.first_name}" + $" {student.last_name}");
                return Ok("Details successfully updated!");
            }
            catch (Exception ex)
            {
                log.Error($"{ex.Message}");
                throw ex;
            }
        }


        [ResponseType(typeof(List<Tutor>))]
        [HttpPost]
        public IHttpActionResult SearchTutorsByArea(string city)
        {
            List<Tutor> tutors = new List<Tutor>();
            try
            {
                tutors = studentFcd.SearchTutorByArea(city);
                return Ok(tutors);
            }
            catch (Exception ex)
            {
                log.Error($"Exception has been thrown: {ex.Message}");
                throw ex;
            }
        }
        [ResponseType(typeof(List<Tutor>))]
        [HttpPost]
        public IHttpActionResult SearchTutorsByName(string firstName, string lastName)
        {
            List<Tutor> tutors = new List<Tutor>();
            try
            {
                tutors = studentFcd.SearchTutorByName(firstName, lastName);
                return Ok(tutors);
            }
            catch (Exception ex)
            {
                log.Error($"Exception has been thrown: {ex.Message}");
                throw ex;
            }
        }

        [ResponseType(typeof(List<Tutor>))]
        [HttpPost]
        public IHttpActionResult SearchTutorsByProfession(string profession)
        {
            List<Tutor> tutors = new List<Tutor>();
            try
            {
                tutors = studentFcd.SearchTutorByProf(profession);
                return Ok(tutors);
            }
            catch (Exception ex)
            {
                log.Error($"Exception has been thrown: {ex.Message}");
                throw ex;
            }
        }

        [HttpDelete]
        [Route("api/Students/Remove_student")]
        public IHttpActionResult DeleteStudent(Student student)
        {
            try
            {
                studentFcd.DeleteStudent(student);
                log.Info($"Student: {student.first_name} {student.last_name} has been removed from database!");
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error($"{ex.Message}");
                throw ex;
            }
        }
    }
}
