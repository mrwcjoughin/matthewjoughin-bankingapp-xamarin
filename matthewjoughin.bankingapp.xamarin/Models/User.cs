using System;
namespace matthewjoughin.bankingapp.xamarin.Models
{
    public class User : ObservableObject
    {
		string _emailAddress = string.Empty;
		string _password = string.Empty;

		public string EmailAddress
		{
			get
			{
				return _emailAddress;
			}
			set
			{
				SetProperty(ref _emailAddress, value);
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				SetProperty(ref _password, value);
			}
		}
    }
}