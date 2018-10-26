using CurrencyWordConverterViewModel.Helpers;
using CurrencyWordPresenter.CurrencyWordConverter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyWordPresenter.ViewModel
{
	public class CurrencyWordConverterViewModel : INotifyPropertyChanged
	{
		private bool _isInValid;
		public bool IsInValid
		{
			get
			{
				return _isInValid;
			}
			set
			{
				if (_isInValid != value)
				{
					_isInValid = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsInValid"));
				}
			}
		}

		private string _resultString;
		public string ResultString {
			get
			{
				return _resultString;
			}
			set
			{
				if (_resultString != value)
				{
					_resultString = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResultString"));
				}
			}
		}

		private string _selectedCurrencySign;
		public string SelectedCurrencySign
		{
			get
			{
				return _selectedCurrencySign;
			}
			set
			{
				if (_selectedCurrencySign != value)
				{
					_selectedCurrencySign = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCurrencySign"));
				}
			}
		}

		public RelayCommand ConvertNumer { get; set; }
		public ObservableCollection<string> CurrencySing { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;

		public CurrencyWordConverterViewModel()
		{
			IsInValid = false;
			SelectedCurrencySign = "$";
			CurrencySing = new ObservableCollection<string>
			{
				"$",
				"€"
			};

			ConvertNumer = new RelayCommand(ConvertNumerToText);
		}

		public void ConvertNumerToText(object numberToConvert)
		{
			var currecnyConverterClient = new CurrencyWordConverterClient();
			if (Double.TryParse(numberToConvert.ToString(), out double value))
			{
				IsInValid = false;
				ResultString = currecnyConverterClient.ConvertCurrency(value, SelectedCurrencySign);
				return;
			}

			IsInValid = true;
		}
	}
}
