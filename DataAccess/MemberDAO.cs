using BusinessObject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static object lockObject = new object();

        private MemberDAO()
        {
        }
        public static MemberDAO Instance
        {
            get
            {
                lock(lockObject)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public Member? CheckLogin(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
            var adminUser = config["AdminAccount:Email"];
            var adminPassword = config["AdminAccount:Password"];
            FstoreContext context = new FstoreContext();
            if (email == adminUser && password == adminPassword)
            {
                return new Member
                {
                    MemberId = 0,
                    Email = email,
                    Password = password
                };
            } else
            {
                return context.Members.SingleOrDefault(m => m.Email.Equals(email)
                && m.Password.Equals(password));
            }
        }

        public List<Member> GetMembers()
        {
            FstoreContext context = new FstoreContext();
            return context.Members.ToList();
        }

        public Member? GetMemberById(int? id)
        {
            FstoreContext context = new FstoreContext();
            return context.Members.SingleOrDefault(member => member.MemberId == id);
        }

        public bool AddMember(Member member)
        {
            if(GetMemberById(member.MemberId) != null) return false;
            FstoreContext context = new FstoreContext();
            context.Members.Add(member);
            var result = context.SaveChanges();
            return result > 0;
        }

        public Member? GetMemberByEmail(string email)
        {
            FstoreContext context = new FstoreContext();
            return context.Members.FirstOrDefault(member => member.Email == email);
        }

        public bool UpdateMember(Member member)
        {
            Member? mem = GetMemberById(member.MemberId);
            if (mem == null) return false;
            FstoreContext context = new FstoreContext();
            mem.CompanyName = member.CompanyName;
            mem.Country = member.Country;
            mem.City = member.City;
            mem.Password = member.Password;
            context.Members.Update(mem);
            var result = context.SaveChanges();
            return result > 0;
        }

        public bool DeleteMember(int id)
        {
            if (GetMemberById(id) == null) return false;
            FstoreContext context = new FstoreContext();
            context.Members.Remove(GetMemberById(id));
            var result = context.SaveChanges();
            return result > 0;
        }
    }
}
