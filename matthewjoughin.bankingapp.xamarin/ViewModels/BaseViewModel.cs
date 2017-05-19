using matthewjoughin.bankingapp.xamarin.Interfaces;
using Xamarin.Forms;

namespace matthewjoughin.bankingapp.xamarin.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        private string _title = string.Empty;
		private bool _isBusy = false;
        private string _errors = string.Empty;
        private IAESEncryptionProvider _aESEncryptionProvider;
		
        public IDataStore<Beneficiary> DataStore => DependencyService.Get<IDataStore<Beneficiary>>();

		public IAESEncryptionProvider AESEncryptionProvider
		{
			get
			{
                if (_aESEncryptionProvider == null)
                {
                    _aESEncryptionProvider = DependencyService.Get<IAESEncryptionProvider>();
                }

				return _aESEncryptionProvider;
			}
		}

        public IKeyProvider KeyProvider
        {
            get
            {
                var result = DependencyService.Get<IKeyProvider>();

                return result;
            }
        }

        public bool IsBusy
        {
            get 
            {
                return _isBusy; 
            }
            set 
            {
                SetProperty(ref _isBusy, value);
            }
        }

        public string Title
        {
            get 
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value); 
            }
        }

		public string Errors
		{
			get { return _errors; }
			set { SetProperty(ref _errors, value); }
		}
    }
}