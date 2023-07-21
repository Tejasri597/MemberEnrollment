using System;
using System.Linq;
using MemberEnrollment.Models;
using MemberEnrollment.Data;

namespace MemberEnrollment.Repositories
{
    public class MemberRepository
    {
        private readonly MemberDbContext _dbContext;

        public MemberRepository(MemberDbContext dbContext)
        {
            _dbContext = dbContext;
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
        public Member GetMemberById(int memberId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _dbContext.Members.FirstOrDefault(m => m.Id == memberId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        // Update an existing member enrollment
        public Member UpdateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member object cannot be null.");
            }

            _dbContext.Members.Update(member);
            _dbContext.SaveChanges();
            return member;
        }

        // Delete a member enrollment
        public void DeleteMember(int memberId)
        {
            var member = _dbContext.Members.FirstOrDefault(m => m.Id == memberId);
            if (member != null)
            {
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
            }
        }
    }
}
