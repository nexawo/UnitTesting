﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBEntityModel
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EnrollmentNo { get; set; }
    }
}
