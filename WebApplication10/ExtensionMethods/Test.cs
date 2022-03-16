using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.ExtensionMethods
{
    public class Test
    {
        public string value = string.Empty;
        private readonly ISession session;
        public Test(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session; ;
        }
        public Test() { }

        public string GetValues()
        {
            if (session != null)
            {
                return session.GetString("user").ToString();
            }
            else
                return null;
        }

        public void SetVlaues(string user)
        {
            if (session != null)
                session.SetString("user", user);

        }

    }
}