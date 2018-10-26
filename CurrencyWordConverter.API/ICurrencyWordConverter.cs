using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CurrencyWordConverter.API
{
	[ServiceContract]
	public interface ICurrencyWordConverter
	{
		[OperationContract]
		string ConvertCurrency(double value, string currencySign);
	}
}
