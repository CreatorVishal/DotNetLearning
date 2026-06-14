using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Entity
{
    public class Course
    {
        public int Id { get; set; }

        public string CourseName { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
