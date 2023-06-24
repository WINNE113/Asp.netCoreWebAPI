using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMemberRepositories
    {
        List<Member> getMember();
        Member GetMemberById(int id);
        void UpdateMember(Member member);
        void DeleteMember(int id);
        void SaveMember (Member member);
    }
}
