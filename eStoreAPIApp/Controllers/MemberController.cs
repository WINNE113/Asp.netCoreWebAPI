using BusinessObject;
using eStoreAPIApp.Data;
using Microsoft.AspNetCore.Mvc;
using Repositories;
namespace eStoreAPIApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MemberController : Controller
    {
        private readonly MemberRepositories memberRepositories;

        public MemberController()
        {
            this.memberRepositories = new MemberRepositories();
        }

        // GET: MemberController
        [HttpGet]
        public ActionResult GetMembers()
        {
            return Ok(memberRepositories.getMember());
        }

        // GET: MemberController/Details/5
        [HttpGet("id")]
        public ActionResult GetMember(int id)
        {
            return Ok(memberRepositories.GetMemberById(id));
        }

        [HttpPost]
        public IActionResult AddMember(MemberToPost memberToPost)
        {
            try
            {
                Member member = new Member()
                {
                    Email = memberToPost.Email,
                    CompanyName = memberToPost.CompanyName,
                    country = memberToPost.country,
                    city = memberToPost.city,
                    passWord = memberToPost.passWord
                };
                memberRepositories.SaveMember(member);
                return Ok(member);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("id")]
        public IActionResult DeleteMember(int id)
        {
            try
            {
                Member member = memberRepositories.GetMemberById(id);
                if (member != null)
                {
                    memberRepositories.DeleteMember(id);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateMember([FromRoute] int id, MemberToUpdate memberToUpdate)
        {
            try
            {
                var member = memberRepositories.GetMemberById(id);
                if (member != null)
                {
                    member.Email = memberToUpdate.Email;
                    member.CompanyName = memberToUpdate.CompanyName;
                    member.country = memberToUpdate.country;
                    member.city = memberToUpdate.city;
                    member.passWord = memberToUpdate.passWord;

                    memberRepositories.UpdateMember(member);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotFound();
        }
    }
}
