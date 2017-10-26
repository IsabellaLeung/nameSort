using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace nameSortTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod] //Tests for names that have more than 3 first names
        public void NameTooLongTest()
        {
            string[] names = {"Andre Marius Padre Narul Medan", "I Have A Long Name", "Testing with dot net core and C#"};
            bool findings;
            foreach (string line in names)
            {
                if (line.Count(Char.IsWhiteSpace) >= 3)
                {
                    findings = true;
                } else
                {
                    findings = false;
                    Assert.IsTrue(findings);
                }
            }
        }

        [TestMethod] //Tests for if line is blank/there is no name
        public void NoNameTest()
        {
            string[] names = { " ", " ", " " };
            bool findings;
            foreach (string line in names)
            {
                if (line == null)
                {
                    findings = true;
                }
                else
                {
                    findings = false;
                    Assert.IsTrue(findings);
                }
            }
        }

        [TestMethod] //Tests for if there's a name with only one name
        public void OneNameTest()
        {
            string[] names = { "Medan", "Name", "Testing" };
            bool findings;
            foreach (string line in names)
            {
                if (line.Count(Char.IsWhiteSpace) <= 1)
                {
                    findings = true;
                }
                else
                {
                    findings = false;
                    Assert.IsTrue(findings);
                    }
                }
            }
        }
    }
}
