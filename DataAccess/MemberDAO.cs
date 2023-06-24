using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        public static List<Member> GetMembers()
        {
            var members = new List<Member>();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    members = context.members.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
        public static Member FindMemberById(int MemberId)
        {
            var member = new Member();
            try
            {
                using(var context = new EStoreDbContext())
                {
                    member = context.members.SingleOrDefault(x => x.MemberId == MemberId);
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public static void UpdateMember(Member member)
        {
            try
            {
                using(var context = new EStoreDbContext())
                {
                    context.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveMember(Member member)
        {
            try
            {
                using(var context = new EStoreDbContext())
                {
                    context.members.Add(member);
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteMember(int MemberId)
        {
            var member = new Member();
            try
            {
                using (var context = new EStoreDbContext())
                {
                    member = context.members.SingleOrDefault(x => x.MemberId == MemberId);
                    context.members.Remove(member);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
    }
}
