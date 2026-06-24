namespace CareerConnectApi.DTOs
{
    public class CreateJobDto
    {
        public string Title { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;

        public decimal Salary { get; set; }
    }
}
