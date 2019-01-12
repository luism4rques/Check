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
            Exception ex = Assert.Throws<Exception>(() => Check.Is.True(false).True(false));
            Assert.Equal("The validation has declared two times.", ex.Message);
        }

        [Fact]
        public void SetMsgTwoTimesMustThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => Check.Is.Msg("").Msg(""));
            Assert.Equal("The msg has declared two times.", ex.Message);
        }

        [Fact]
        public void SetMsgNullMustThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => Check.Is.Msg(null));
            Assert.Equal("The msg can't be null.", ex.Message);
        }

        [Fact]
        public void IsValidWithoutValueMustThrowException()
        {
            Exception ex = Assert.Throws<Exception>(() => Check.Is.IsValid());
            Assert.Equal("The validation must be declared.", ex.Message);
        }

        [Fact]
        public void ThrowWithInvalidConditionMostThrowExceptionWithoutMessage()
        {
            Exception ex = Assert.Throws<Exception>(() => Check.Is.True(false).Throw());
            Assert.Equal(string.Empty, ex.Message);
        }

        [Theory]
        [InlineData(false, "MSG1")]
        [InlineData(false, "")]
        public void ThrowWithInvalidConditionMostThrowExceptionWithOneMessage(bool val, string msg)
        {
            Exception ex = Assert.Throws<Exception>(() => Check.Is.True(val).Msg(msg).Throw());
            Assert.Equal(msg, ex.Message);
        }

        [Theory]
        [InlineData(false, "MSG1", false, "MSG2")]
        [InlineData(false, "", false, "")]
        public void ThrowWithInvalidConditionMostThrowExceptionWithTwoMessage(bool val1, string msg1, bool val2, string msg2)
        {
            Exception ex = Assert.Throws<Exception>(() => Check.Is.True(val1).Msg(msg1).AndIs.True(val2).Msg(msg2).Throw());
            Assert.Contains(msg1, ex.Message);
            Assert.Contains(msg2, ex.Message);
        }

        private class MyException : Exception { 
            public MyException(){}
            public MyException(string message):base(message){}
        }

        [Fact]
        public void ThrowWithCustomException()
        {
            var ex = Assert.Throws<MyException>(() => Check.Is.True(false).Msg("MSG1").Throw<MyException>());
            Assert.IsType<MyException>(ex);
            Assert.Contains("MSG1", ex.Message);
        }
    }
}