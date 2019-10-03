using DAL.DBEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    class StudentRepositoryFake : IStudentRepository
    {
        private readonly List<Student> _student;

        public StudentRepositoryFake()
        {
            _student = new List<Student>()
            {
                new Student() { Id = 1, FirstName = "jarar", LastName = "tahir", Email = "jarartahir@gmail.com", EnrollmentNo = "0901"},
                new Student() { Id = 2, FirstName = "shahid", LastName = "khan", Email = "shahid@gmail.com", EnrollmentNo = "0902"},
                new Student() { Id = 3, FirstName = "zain", LastName = "abid", Email = "zain@gmail.com", EnrollmentNo = "0903"}
            };
        }
      

        public void SaveStudent(Student student)
        {
            for (int i=0; i < 3; i++)
            {
                student.Id = i;
            }
            _student.Add(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _student;
        }

        public Student GetStudent(long id)
        {
            return _student.Where(s => s.Id == id).FirstOrDefault();
        }

        public void DeleteStudent(long id)
        {
            Student student = GetStudent(id);
            _student.Remove(student);
        }
        public void UpdateStudent(Student student)
        {
            
        }
    }
}
