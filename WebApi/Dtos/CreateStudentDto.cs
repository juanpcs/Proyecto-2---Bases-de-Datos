using System;

namespace WebApi.Dtos
{
    public class CreateStudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ParentName { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
    }
}