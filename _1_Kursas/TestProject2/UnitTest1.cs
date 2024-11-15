using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Diagnostics.CodeAnalysis;

namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var countries = new Dictionary<string, string>
            {
                { "Germany", "Berlin"},
                { "Lithuania", "Vilnius"},
                { "Latvia", "Riga"},
                { "Sweden", "Stockholm"}
            };

            string expected = "Berlin";
            string actual = Methods.GetCapital("Germany", countries);

            Assert.That(actual, Is.SameAs(expected));
        }
    }
}