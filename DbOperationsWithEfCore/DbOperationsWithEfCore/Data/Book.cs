using System.ComponentModel.DataAnnotations;
namespace DbOperationsWithEfCore.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Same { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Title  { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Range(1, 5000)]
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int Country { get; set; }
    }
}
