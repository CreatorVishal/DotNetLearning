using System.ComponentModel.DataAnnotations;
namespace CareerConnectApi.DTOs
{
    public class CreateCompanyDto
    {

        //[Required]
        //[StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
      


    }
}
