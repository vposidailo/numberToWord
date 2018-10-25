using CurrencyWordConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWordConverter.Mapper
{
	public static class CurrencyMapper
	{
		public static IDictionary<string, CurrencyWord> CurrecySignToWord = new Dictionary<string, CurrencyWord>()
		{
			{ "$", new CurrencyWord(){ NoteSingle = "dollar", NotePlural = "dollars", CoinSingle="cent", CoinPlural="cents"} },
			{ "€", new CurrencyWord(){ NoteSingle = "euro", NotePlural = "euros", CoinSingle="cent", CoinPlural="cents"} }
		};
	}
}
