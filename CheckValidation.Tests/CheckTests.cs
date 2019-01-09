using System;
using Xunit;
using ValidationCheck;

namespace CheckValidation.Tests
{
    public class CheckTests
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

        [Fact]
        public void SetValueTwoTimesMustThrowException()
        {
            Exception ex = Assert.Throws<Exception>(()=> Check.Is.True(false).True(false));
            Assert.Equal("The validation has declared two times.", ex.Message);
        }

        [Fact]
        public void SetMsgTwoTimesMustThrowException()
        {
            Exception ex = Assert.Throws<Exception>(()=> Check.Is.Msg("").Msg(""));
            Assert.Equal("The msg has declared two times.", ex.Message);
        }
    }
}
