using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserInfo :CommonInfo
    {
        public Guid id{get;set;}
        public string UserID{get;set;}
        public string Password{get;set;}
        public string UserName{get;set;}
        public string Email { get; set; }
    }
}
