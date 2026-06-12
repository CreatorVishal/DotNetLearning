namespace EFPractice.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department Department { get; set; }
    }
}



//-----------------------------
//---------------------------------------

//[Key]
//public int RollNo { get; set; }
//[Required]
//[MaxLength(20)]
////string length-> minimum + maximum
//[StringLength(20,MinimumLength =5)]
////Column ka name change krna ho to [Column("StudentName")]
//public string Name { get; set; }
//[Range(18,65)]
// public int Age { get; set; }

//[EmailAddress]
////[NotMapped]----------->database me column mt bnana
//public string Email { get; set; }

////[Phone]
////public string MobileNo { get; set; }
//public int DepartmentId { get; set; }
//public Department Department { get; set; }