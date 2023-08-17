using MemberEnrollment.Data;
using MemberEnrollment.Model;
using MemberEnrollment.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MemberEnrollment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepor;

        public MemberController(IMemberRepository memberRepor)
        {
            _memberRepor = memberRepor;
        }
        [HttpGet(Name = "GetMembers")]
        public IEnumerable<Member> GetMembers() {
            return _memberRepor.GetAll();
        }

        [HttpPost(Name ="CreateMember")]
        public IActionResult CreateMember([FromBody] Member member)
        {
            if (ModelState.IsValid)
            {
                _memberRepor.CreateMember(member);
                return Ok("Member enrollment successful.");
            }

            return BadRequest("Invalid member data.");
        }
    }
}
