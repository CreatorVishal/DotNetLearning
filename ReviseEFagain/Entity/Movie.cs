using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReviseEFagain.Entity
{
    //[Table("MoviesData")]
    public class Movie
    {
        //Data Annotations
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Range(1900,2100)]
        public int ReleaseYear { get; set; }
        [Range(1,10)]
        public decimal Rating { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string Description { get; set; }
        [EmailAddress]
        public string DirectorEmail { get; set; }
        //[Column("Movie_Code")]--> Name change krne ke liye
        [Column("Movie_Code")]
        public string MovieCode { get; set; }
        //[NotMapped]-->Database me column create nhi hogi 
        public string TempData { get; set; }
        public List<Review> Reviews { get; set; } = new();
        public MovieDetail MovieDetail { get; set; }

    }
}
