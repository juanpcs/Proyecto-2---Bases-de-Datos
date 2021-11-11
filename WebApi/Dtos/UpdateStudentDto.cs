using System;

namespace WebApi.Dtos
{
    public class UpdateStudentDto
    {
        public string StudentName { get; set; }
        public string ParentName { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
    }
}