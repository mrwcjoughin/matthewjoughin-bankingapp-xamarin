using System.Threading.Tasks;
using System.Windows.Input;
using System.Security.Cryptography;

using Xamarin.Forms;
using System.Text;
using System;
using matthewjoughin.bankingapp.xamarin.Models;

namespace matthewjoughin.bankingapp.xamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
		string _emailAddress = string.Empty;
		string _password = string.Empty;
        string _message = string.Empty;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            NotNowCommand = new Command(App.GoToMainPage);

            Title =  "Login";
        }

        public string Message
        {
            get 
            {
                return _message; 
            }
            set
            {
                SetProperty(ref _message, value);
                OnPropertyChanged(); 
            }
        }

        public ICommand NotNowCommand { get; }
        public ICommand LoginCommand { get; }

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

        async Task Login()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                string testString = "Test";
				string key = await KeyProvider.Key();
				string salt = await KeyProvider.Salt();

				byte[] encryptedBytes = this.AESEncryptionProvider.EncryptData256(Encoding.ASCII.GetBytes(testString), key, salt);
				byte[] unEncryptedBytes = this.AESEncryptionProvider.DecryptData256(encryptedBytes, key, salt);

				var result = Encoding.ASCII.GetString(unEncryptedBytes);

                if (!testString.Equals(result))
                {
                    throw new Exception("AES Encryption Test Failed!");
                }

                // Log the user in
                if (await TryLoginAsync())
                {
                    App.GoToMainPage();
                }
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

                if (Settings.IsLoggedIn)
                {
                    App.GoToMainPage();
                }
            }
        }

        public async Task<bool> TryLoginAsync()
        {
            bool result = false;

            Errors = string.Empty;

            if (EmailAddress.Length < 5)
            {
                Errors = "User name too short";
            }
            if (Password.Length < 5)
            {
                if (Errors.Length > 0)
                {
                    Errors += Environment.NewLine;
                }
                Errors += "Password too short";
            }

            if (Errors.Length == 0)
            {
                User user = new User();

                user.EmailAddress = EmailAddress;
                user.Password = Password;

                //TODO Call Login Service with the user
            }

            result = (Errors.Length == 0);

            return result;
        }
    }
}