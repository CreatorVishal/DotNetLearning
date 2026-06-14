using AdventureClubDb.Data;
using AdventureClubDb.Entity;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

//var student = new Student
//{
//    Name = "Vishal"
//};

//var course1 = new Course
//{
//    CourseName = "C#"
//};

//var course2 = new Course
//{
//    CourseName = "ASP.NET"
//};

//student.Courses.Add(course1);
//student.Courses.Add(course2);

//db.Students.Add(student);

//db.SaveChanges();
var students = db.Students
                 .Include(s => s.Courses)
                 .ToList();
foreach (var student in students)
{
    Console.WriteLine($"Student: {student.Name}");

    foreach (var course in student.Courses)
    {
        Console.WriteLine($"   Course: {course.CourseName}");
    }
}