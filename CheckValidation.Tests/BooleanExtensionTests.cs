using System;
using Xunit;
using ValidationCheck;

namespace CheckValidation.Tests
{
    public class BooleanExtensionTests
    {
        [Fact]
        public void IsTrueTest()
        {
            var result = Check.Is.True(true).IsValid();
            Assert.True(result);

            result = Check.Is.True(false).IsValid();
            Assert.False(result);
        }

        [Fact]
        public void IsNotTrueTest()
        {
            var result = Check.IsNot.True(true).IsValid();
            Assert.False(result);

            result = Check.IsNot.True(false).IsValid();
            Assert.True(result);
        }

        [Fact]
        public void IsBoolAndIsBoolMustBeTrue()
        {
            var result = Check.Is.True(true).AndIs.True(true).IsValid();
            Assert.True(result);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void IsBoolAndIsBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.Is.True(val1).AndIs.True(val2).IsValid();
            Assert.False(result);
        }

        [Fact]
        public void IsBoolAndIsNotBoolMustBeTrue()
        {
            var result = Check.Is.True(true).AndIsNot.True(false).IsValid();
            Assert.True(result);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(false, true)]
        public void IsBoolAndIsNotBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.Is.True(val1).AndIsNot.True(val2).IsValid();
            Assert.False(result);
        }

        [Fact]
        public void IsNotBoolAndIsBoolMustBeTrue()
        {
            var result = Check.IsNot.True(false).AndIs.True(true).IsValid();
            Assert.True(result);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        public void IsNotBoolAndIsBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.IsNot.True(val1).AndIs.True(val2).IsValid();
            Assert.False(result);
        }

        [Fact]
        public void IsNotBoolAndIsNotBoolMustBeTrue()
        {
            var result = Check.IsNot.True(false).AndIsNot.True(false).IsValid();
            Assert.True(result);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void IsNotBoolAndIsNotBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.IsNot.True(val1).AndIsNot.True(val2).IsValid();
            Assert.False(result);
        }
    }
}