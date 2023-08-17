using MemberEnrollment.Model;
using Microsoft.EntityFrameworkCore;

public interface IMemberRepository
{
    List<Member> GetAll();

    // Create a new member enrollment
    Member CreateMember(Member member);
}