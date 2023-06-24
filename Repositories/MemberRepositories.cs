using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MemberRepositories : IMemberRepositories
    {
     
        public void DeleteMember(int id) => MemberDAO.DeleteMember(id);

        public List<Member> getMember() => MemberDAO.GetMembers();

        public Member GetMemberById(int id) => MemberDAO.FindMemberById(id);

        public void SaveMember(Member member) => MemberDAO.SaveMember(member);

        public void UpdateMember(Member member) => MemberDAO.UpdateMember(member);
    }
}
