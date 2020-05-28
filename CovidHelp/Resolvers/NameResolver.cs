using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelp.Resolvers
{
    public static class NameResolver
    {
        public static String FullNameToFirstName(string fullName)
        {
            return fullName.Split(" ")[0];
        }

        public static String FullNameToLastName(string fullName)
        {
            return fullName.Split(" ")[1];
        }
    }
}
