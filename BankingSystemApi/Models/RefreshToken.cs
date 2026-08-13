namespace BankingSystemApi.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
        public User User   { get; set; }
        public DateTime ExpireAt{ get; set; }
        public DateTime CreatedAt{ get; set; }
        public  DateTime? RevokedAt{ get; set; }
       
    }
}
