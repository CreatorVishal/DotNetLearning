using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbOperationsWithEfCore.Data
{
    [Table("Students")]
    public class Student
    {
        // PRIMARY KEY
         [Key]
        public int Id { get; set; }


        // REQUIRED + LENGTH
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }


        // RANGE
        [Range(18, 30)]
        public int Age { get; set; }


        // EMAIL VALIDATION
        [EmailAddress]
        public string Email { get; set; }


        // PHONE VALIDATION
        [Phone]
        public string PhoneNumber { get; set; }


        // COLUMN NAME CHANGE
        [Column("Student_City")]
        public string City { get; set; }


        // DECIMAL TYPE
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fees { get; set; }


        // DATE TYPE
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        // MAX LENGTH
        [MaxLength(200)]
        public string Address { get; set; }


        // IGNORE COLUMN
        [NotMapped]
        public string TempData { get; set; }
    }
}