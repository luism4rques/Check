using System;
using Xunit;
using ValidationCheck;

namespace CheckValidation.Tests
{
    public class BooleanExtensionTests
    {
        [Fact]
        public void IsBoolMustBeTrue()
        {
            var result = Check.Is.True(true).IsValid();
            Assert.True(result);

            var resultFunc = Check.Is.True(()=>true).IsValid();
            Assert.True(resultFunc);
        }

        [Fact]
        public void IsBoolMustBeFalse()
        {
            var result = Check.Is.True(false).IsValid();
            Assert.False(result);

            var resultFunc = Check.Is.True(()=>false).IsValid();
            Assert.False(resultFunc);
        }

        [Fact]
        public void IsNotBoolMustBeTrue()
        {
            var result = Check.IsNot.True(false).IsValid();
            Assert.True(result);

            var resultFunc = Check.IsNot.True(()=>false).IsValid();
            Assert.True(resultFunc);
        }

        [Fact]
        public void IsNotBoolMustBeFalse()
        {
            var result = Check.IsNot.True(true).IsValid();
            Assert.False(result);

            var resultFunc = Check.IsNot.True(()=>true).IsValid();
            Assert.False(resultFunc);
        }

        [Fact]
        public void IsBoolAndIsBoolMustBeTrue()
        {
            var result = Check.Is.True(true).AndIs.True(true).IsValid();
            Assert.True(result);

            var resultFunc = Check.Is.True(()=>true).AndIs.True(()=>true).IsValid();
            Assert.True(resultFunc);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void IsBoolAndIsBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.Is.True(val1).AndIs.True(val2).IsValid();
            Assert.False(result);

            var resultFunc = Check.Is.True(()=>true).AndIs.True(()=>true).IsValid();
            Assert.True(resultFunc);
        }

        [Fact]
        public void IsBoolAndIsNotBoolMustBeTrue()
        {
            var result = Check.Is.True(true).AndIsNot.True(false).IsValid();
            Assert.True(result);

            var resultFunc = Check.Is.True(()=>true).AndIsNot.True(()=>false).IsValid();
            Assert.True(resultFunc);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(false, true)]
        public void IsBoolAndIsNotBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.Is.True(val1).AndIsNot.True(val2).IsValid();
            Assert.False(result);

            var resultFunc = Check.Is.True(()=>val1).AndIsNot.True(()=>val2).IsValid();
            Assert.False(resultFunc);
        }

        [Fact]
        public void IsNotBoolAndIsBoolMustBeTrue()
        {
            var result = Check.IsNot.True(false).AndIs.True(true).IsValid();
            Assert.True(result);

            var resultFunc = Check.IsNot.True(()=>false).AndIs.True(()=>true).IsValid();
            Assert.True(resultFunc);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        public void IsNotBoolAndIsBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.IsNot.True(val1).AndIs.True(val2).IsValid();
            Assert.False(result);

            var resultFunc = Check.IsNot.True(()=>val1).AndIs.True(()=>val2).IsValid();
            Assert.False(resultFunc);
        }

        [Fact]
        public void IsNotBoolAndIsNotBoolMustBeTrue()
        {
            var result = Check.IsNot.True(false).AndIsNot.True(false).IsValid();
            Assert.True(result);

            var resultFunc = Check.IsNot.True(()=>false).AndIsNot.True(()=>false).IsValid();
            Assert.True(resultFunc);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void IsNotBoolAndIsNotBoolMustBeFalse(bool val1, bool val2)
        {
            var result = Check.IsNot.True(val1).AndIsNot.True(val2).IsValid();
            Assert.False(result);

            var resultFunc = Check.IsNot.True(()=>val1).AndIsNot.True(()=>val2).IsValid();
            Assert.False(resultFunc);
        }
    }
}