using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool AddMember(Member member)
        {
            return MemberDAO.Instance.AddMember(member);
        }

        public Member? CheckLogin(string email, string password)
        {
            return MemberDAO.Instance.CheckLogin(email, password);
        }

        public bool DeleteMember(int id)
        {
            return MemberDAO.Instance.DeleteMember(id);
        }

        public Member? GetMember(int? id)
        {
            return MemberDAO.Instance.GetMemberById(id);
        }

        public Member? GetMemberByEmail(string email)
        {
            return MemberDAO.Instance.GetMemberByEmail(email);
        }

        public ICollection<Member> GetMembers()
        {
            return MemberDAO.Instance.GetMembers();
        }

        public bool UpdateMember(Member member)
        {
            return MemberDAO.Instance.UpdateMember(member);
        }
    }
}
