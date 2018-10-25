namespace CurrencyWordConverter.Converter
{
	public interface ICurrencyToWordConverter
	{
		string ConvertCurrencyToWord(double number, string currencySign);
	}
}