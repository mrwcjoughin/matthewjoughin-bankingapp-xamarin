using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace matthewjoughin.bankingapp.xamarin.ViewModels
{
    public class LogoutViewModel
    {
        public ICommand LogoutCommand { get; }

		public LogoutViewModel()
		{
			LogoutCommand = new Command(Logout);
		}

        private void Logout()
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}