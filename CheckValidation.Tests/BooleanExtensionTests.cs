using System;
using Xunit;
using ValidationCheck;

namespace CheckValidation.Tests
{
    public class BooleanExtensionTests
    {
        [Fact]
        public void TrueWithIsTest()
        {
            var result = Check.Is.True(true).Validate();
            Assert.True(result);

            result = Check.Is.True(false).Validate();
            Assert.False(result);
        }

        [Fact]
        public void TrueWithIsNotTest()
        {
            var result = Check.IsNot.True(true).Validate();
            Assert.False(result);

            result = Check.IsNot.True(false).Validate();
            Assert.True(result);
        }
    }
}