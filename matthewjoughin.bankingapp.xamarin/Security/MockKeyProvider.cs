using System;
using System.Text;
using System.Threading.Tasks;
using matthewjoughin.bankingapp.xamarin.Helpers;
using matthewjoughin.bankingapp.xamarin.Interfaces;
using PCLStorage;
using System.Reflection;

namespace matthewjoughin.bankingapp.xamarin.Security
{
    public class MockKeyProvider : IKeyProvider
    {
        //private IKeyProvider _sharedInstance = new MockKeyProvider();
        private string _keyFileName = "aes-256-key.bin";
        private string _saltFileName = "aes-128-key.bin";
        private string _key = null;
        private string _salt = "HR$2pIjHR$2pIj17";

        public async Task<string> Key()
        {
            if (_key == null)
            {
                await InitKey();
            }

            return _key;
        }

        public async Task<string> Salt()
        {
			if (_salt == null)
			{
				await InitSalt();
			}

			return _salt;
        }

        private async Task InitKey()
        {
            var keyBytes = ResourceLoader.GetEmbeddedResourceBytes(this.GetType().GetTypeInfo().Assembly, _keyFileName);

            _key = Encoding.ASCII.GetString(keyBytes);
        }

		private async Task InitSalt()
		{
			var saltBytes = ResourceLoader.GetEmbeddedResourceBytes(this.GetType().GetTypeInfo().Assembly, _saltFileName);

			_salt = Encoding.ASCII.GetString(saltBytes);
		}
    }
}