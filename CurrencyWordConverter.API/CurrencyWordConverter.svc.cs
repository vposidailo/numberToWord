using NumbersToWordPresentatConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CurrencyWordConverter.API
{
	public class CurrencyWordConverter : ICurrencyWordConverter
	{
		public string ConvertCurrency(double value)
		{
			var currencyWordConverter = new CurrencyToWordConverter();
			return currencyWordConverter.ConvertCurrencyToWord(value, "$");
		}
	}
}
