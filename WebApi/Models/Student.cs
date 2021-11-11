using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ParentName { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }

    }
}