using ECommerceApi.CustomValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiUnitTests.CreditCardValidation
{
    public class ValidatingCreditCardNumberTests
    {
        [Theory]
        [InlineData("49927398716")]
        [InlineData("1234567812345670")]
        [InlineData("4417 1234 5678 9113")]
        [InlineData("4417-1234-5678-9113")]
        public void ValidCreditCardNumbers(string ccNum)
        {
            var checker = new LuhnCheck();
            Assert.True(checker.PassesLuhnCheck(ccNum));
        }

        [Theory]
        [InlineData("49927398717")]
        [InlineData("1234567812345678")]
        [InlineData("")]
        [InlineData("1234-5678-1234 5678")]
        [InlineData("4417 1234 5678 9123")]
        [InlineData("Dog")]
        [InlineData("1234piza")]
        [InlineData("---- -- - ")]
        public void InvalidCreditCardNumbers(string ccNum)
        {
            var checker = new LuhnCheck();
            Assert.False(checker.PassesLuhnCheck(ccNum));
        }

    }
}

