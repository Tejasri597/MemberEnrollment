using MemberEnrollment;
using MemberEnrollment.Models;
using MemberEnrollment.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace MemberEnrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberRepository _memberRepository;

        public MemberController(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpPost]
        public IActionResult CreateMember([FromBody] Member member)
        {
            if (ModelState.IsValid)
            {
                _memberRepository.CreateMember(member);
                return Ok("Member enrollment successful.");
            }

            return BadRequest("Invalid member data.");
        }
    }
}
