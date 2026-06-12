using EFPractice.Data;
using EFPractice.Entity;

AppDbContext db = new AppDbContext();

Department d1 = new Department()
{
    Name = "IT"
};

Department d2 = new Department()
{
    Name = "HR"
};

db.Departments.AddRange(d1, d2);

db.SaveChanges();

Console.WriteLine("Department Inserted Successfully");

Console.ReadLine();