using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomnaCarProject
{
    public class Singletone
    {

        public static string LogedUser = "Admin";
        public static string uRole = "Administrator";
        public static int userID = 0;
        public static int docDetails { get; set; } = 0;
        public static decimal docQuantity { get; set; } = 0;
        public static ClassDocumentDetails classDoc { get; set; } = null;
        public static List<PeopleClass> PeopleIDList = new List<PeopleClass>();

    }
}
