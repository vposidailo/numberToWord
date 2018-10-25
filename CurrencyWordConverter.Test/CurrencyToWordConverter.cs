using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersToWordPresentatConverter;
using NUnit.Framework;

namespace CurrencyWordConverter.Test
{
	[TestFixture]
	public class NumberToWordTest
	{
		private CurrencyToWordConverter _sut;

		[SetUp]
		public void Initialize()
		{
			_sut = new CurrencyToWordConverter();
		}

		[TestCase(0, "zero dollars")]
		[TestCase(1, "one dollar")]
		[TestCase(2, "two dollars")]
		[TestCase(3, "three dollars")]
		[TestCase(4, "four dollars")]
		[TestCase(5, "five dollars")]
		[TestCase(6, "six dollars")]
		[TestCase(7, "seven dollars")]
		[TestCase(8, "eight dollars")]
		[TestCase(9, "nine dollars")]
		[TestCase(10, "ten dollars")]
		[TestCase(11, "eleven dollars")]
		[TestCase(12, "twelve dollars")]
		[TestCase(13, "thirteen dollars")]
		[TestCase(14, "fourteen dollars")]
		[TestCase(15, "fifteen dollars")]
		[TestCase(16, "sixteen dollars")]
		[TestCase(17, "seventeen dollars")]
		[TestCase(18, "eighteen dollars")]
		[TestCase(19, "nineteen dollars")]
		[TestCase(20, "twenty dollars")]
		[TestCase(21, "twenty-one dollars")]
		[TestCase(26, "twenty-six dollars")]
		[TestCase(30, "thirty dollars")]
		[TestCase(32, "thirty-two dollars")]
		[TestCase(37, "thirty-seven dollars")]
		[TestCase(40, "forty dollars")]
		[TestCase(43, "forty-three dollars")]
		[TestCase(48, "forty-eight dollars")]
		[TestCase(50, "fifty dollars")]
		[TestCase(54, "fifty-four dollars")]
		[TestCase(59, "fifty-nine dollars")]
		[TestCase(60, "sixty dollars")]
		[TestCase(65, "sixty-five dollars")]
		[TestCase(70, "seventy dollars")]
		[TestCase(80, "eighty dollars")]
		[TestCase(90, "ninty dollars")]
		[TestCase(100, "one hundred dollars")]
		[TestCase(200, "two hundred dollars")]
		[TestCase(300, "three hundred dollars")]
		[TestCase(400, "four hundred dollars")]
		[TestCase(500, "five hundred dollars")]
		[TestCase(610, "six hundred ten dollars")]
		[TestCase(723, "seven hundred twenty-three dollars")]
		[TestCase(856, "eight hundred fifty-six dollars")]
		[TestCase(944, "nine hundred forty-four dollars")]
		[TestCase(1000, "one thousand dollars")]
		[TestCase(2000, "two thousand dollars")]
		[TestCase(10000, "ten thousand dollars")]
		[TestCase(110000, "one hundred ten thousand dollars")]
		[TestCase(120000, "one hundred twenty thousand dollars")]
		[TestCase(0.01, "zero dollars and one cent")]
		[TestCase(0.02, "zero dollars and two cents")]
		[TestCase(0.99, "zero dollars and ninty-nine cents")]
		[TestCase(2.89, "two dollars and eighty-nine cents")]
		[TestCase(2.00, "two dollars")]
		[TestCase(0.1, "zero dollars and ten cents")]
		public void ConvertNumber(double number, string expectedResult)
		{
			// Act
			var acttual = _sut.ConvertCurrencyToWord(number, "$");

			// Assert(s)
			acttual.Should().Be(expectedResult);
		}
	}
}
