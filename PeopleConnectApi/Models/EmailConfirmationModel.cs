namespace PeopleConnectApi.Models
{
    public class EmailConfirmationModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string ConfirmationLink { get; set; } = string.Empty;
    }
}
