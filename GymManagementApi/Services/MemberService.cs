using GymManagementApi.Models;

namespace GymManagementApi.Services
{
    public interface IMemberService
    {
        public Task SaveRecord(Member member);
    }
    public class MemberService:IMemberService
        {
            public async Task SaveRecord(Member member)
            {


            }
        }
    }

