using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.AssertHelpers
{
    public class ProfileAddandUpdateUsernameAssert
    {
        public static void  assertUpdateUserName(string actual, string expected)
        {
            Assert.AreEqual(expected, actual, "The actual and expected not equal");  
        }

    
    }
}
