using System;
using Xunit;
using ValidationCheck;

namespace CheckValidation.Tests
{
    public class CreateInstanceTests
    {
        [Fact]
        public void CreateInstaceOfIs()
        {
            Assert.IsType<Check>(Check.Is);
        }

        [Fact]
        public void CreateInstanceOfIsNot()
        {
            Assert.IsType<Check>(Check.IsNot);
        }
    }
}
