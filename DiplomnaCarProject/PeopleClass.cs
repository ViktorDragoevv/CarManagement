using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomnaCarProject
{
    public class PeopleClass
    {
        public string id { get; set; }

        public string name { get; set; }
        public string mail { get; set; }
        public override string ToString()
        {
            return "Person: " + name + " " + mail;
        }
        public PeopleClass() { }
        public PeopleClass(string mail)
        {
            this.mail = mail;
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

     
    

}
