using System.ComponentModel.DataAnnotations;

namespace GymManagementApi.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        [Required]
        public string MembershipType { get; set; }
    }
}
