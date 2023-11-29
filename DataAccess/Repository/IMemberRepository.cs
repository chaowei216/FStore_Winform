using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        ICollection<Member> GetMembers();
        Member? GetMember(int? id);
        Member? GetMemberByEmail(string email);
        Member? CheckLogin(string email, string password);
        bool AddMember(Member member);
        bool UpdateMember(Member member);
        bool DeleteMember(int id);
    }
}
