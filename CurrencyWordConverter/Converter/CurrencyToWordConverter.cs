using CurrencyWordConverter.Converter;
using CurrencyWordConverter.Mapper;
using CurrencyWordConverter.Model;
using NumbersToWordPresentatConverter.Mapper;
using System;
using System.Linq;

namespace NumbersToWordPresentatConverter
{
	public class CurrencyToWordConverter : ICurrencyToWordConverter
	{
		public string ConvertCurrencyToWord(double number, string currencySign)
		{
			string[] numberArray = number.ToString().Split(',');
			CurrencyMapper.CurrecySignToWord.TryGetValue(currencySign, out CurrencyWord currencyWord);

			string noteDelimitter = Convert.ToInt32(numberArray[0]) == 1 
				? currencyWord.NoteSingle
				: currencyWord.NotePlural;

			string centDelimitter = numberArray.Count() == 2 && Convert.ToInt32(numberArray[1]) == 1 
				? currencyWord.CoinSingle
				: currencyWord.CoinPlural;

			return numberArray.Count() == 2
				? $"{ConverDollars(Convert.ToInt32(numberArray[0]))} {noteDelimitter} and {ConvertHundred(Convert.ToInt32(numberArray[1]))} {centDelimitter}"
				: $"{ConverDollars(Convert.ToInt32(numberArray[0]))} {noteDelimitter}";
		}

		public string ConverDollars(int amount)
		{
			string returnString = string.Empty;
			if (amount == 0)
			{
				return "zero";
			}

			if (amount / 1000000 > 0)
			{
				returnString += string.Format($"{ConvertHundred(amount / 1000000)} million");
				amount %= 1000000;
			}

			if (amount / 1000 > 0)
			{
				returnString += string.Format($"{ConvertHundred(amount / 1000)} thousand");
				amount %= 1000;
			}

			return amount != 0
				? returnString += string.Format($"{ConvertHundred(amount)}")
				: returnString;
		}

		public string ConvertHundred(int number)
		{
			if(NumberToWordMapper.NumberToWord.TryGetValue(number, out string wordValue))
			{
				return wordValue;
			}

			string numberDelimiter = string.Empty;
			int powerOfTen = number.ToString().Length - 1;
			int mainNumberPart = number / (int)Math.Pow(10, powerOfTen);
			int remaineNumberPart = number % (int)Math.Pow(10, powerOfTen);

			switch(powerOfTen)
			{
				case 2:
					numberDelimiter = " hundred ";
					break;
				case 1:
					numberDelimiter = "-";
					mainNumberPart *= 10;
					break;
			}

			return remaineNumberPart != 0
				? string.Format($"{NumberToWordMapper.NumberToWord[mainNumberPart]}{numberDelimiter}{ConvertHundred(remaineNumberPart)}")
				: string.Format($"{NumberToWordMapper.NumberToWord[mainNumberPart]}{numberDelimiter}").TrimEnd();
		}
	}
}
