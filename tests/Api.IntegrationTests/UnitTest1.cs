using Xunit;
using System.Collections.Generic;

namespace Api.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var test = new List<string>();
            Assert.Empty(test);
        }
    }
}