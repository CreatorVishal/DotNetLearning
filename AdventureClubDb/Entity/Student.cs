using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureClubDb.Entity
{

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Course> Courses { get; set; } = new();
    }

}
