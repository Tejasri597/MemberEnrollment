using System;
using System.Linq;
using MemberEnrollment.Data;
using MemberEnrollment.Model;

namespace MemberEnrollment.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly MemberDbContext _dbContext;

        public MemberRepository(MemberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Member> GetAll() {

           return _dbContext.Members.ToList();
        }

        // Create a new member enrollment
        public Member CreateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member object cannot be null.");
            }

            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            return member;
        }

        // Read a member by ID
      
    }
}
