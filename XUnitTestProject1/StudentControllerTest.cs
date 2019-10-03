using DAL.DBEntityModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentApplication.Controllers;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class StudentControllerTest
    {
        private readonly Mock<IStudentRepository> _SR;
        private readonly StudentController _controller;

        public StudentControllerTest()
        {
            _SR = new Mock<IStudentRepository>();
            _controller = new StudentController(_SR.Object);
        }
        [Fact]
        public void Index_ActionExecute_ReturnsViewforIndex()
        {
            //act
            var result = _controller.Index();
            //assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AddEditStudent_ActionExecute_ReturnPartialViewforAddorEdit()
        {
            //act
            var result = _controller.AddEditStudent(1);

            //assert
            Assert.IsType<PartialViewResult>(result);
        }

        [Fact]
        public void Add_ModelStateValid_AddStudentCalledOnce()
        {
            Student std = null;
            _SR.Setup(r => r.SaveStudent(It.IsAny<Student>()))
                .Callback<Student>(x => std = x);

            StudentViewModel model = new StudentViewModel();

            Student student = new Student
            {
                Id = 1,
                FirstName = "jarar",
                LastName = "tahir",
                Email = "jarar@gmail.com",
                EnrollmentNo = "01"

            };

            model.Id = student.Id;
            model.FirstName = student.FirstName;
            model.LastName = student.LastName;
            model.Email = student.Email;
            model.EnrollmentNo = student.EnrollmentNo;

            //act
            _controller.AddEditStudent(null, model);

            _SR.Verify(x => x.SaveStudent(It.IsAny<Student>()), Times.Once);

            Assert.Equal(model.Id, student.Id);
            Assert.Equal(std.FirstName, student.FirstName);
            Assert.Equal(std.LastName, student.LastName);
            Assert.Equal(std.Email, student.Email);
            Assert.Equal(std.EnrollmentNo, student.EnrollmentNo);
        }

    }


}
