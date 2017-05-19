using System;

using Newtonsoft.Json;

namespace matthewjoughin.bankingapp.xamarin
{
    public class Beneficiary : ObservableObject
    {
        string _id = string.Empty;
        string _name = string.Empty;
		string _bank = string.Empty;
		string _accountType = string.Empty;
		string _accountNo = string.Empty;

		[JsonIgnore]
        public string Id
        {
            get
            {
                return _id; 
            }
            set
            {
                SetProperty(ref _id, value); 
            }
        }

        public string Name
        {
            get
            {
                return _name; 
            }
            set
            {
                SetProperty(ref _name, value); 
            }
        }

        public string Bank
        {
            get
            {
                return _bank; 
            }
            set
            {
                SetProperty(ref _bank, value); 
            }
        }

		public string AccountType
		{
			get
            {
                return _accountType; 
            }
			set
            {
                SetProperty(ref _accountType, value); 
            }
		}

		public string AccountNo
		{
			get
            {
                return _accountNo; 
            }
			set
            {
                SetProperty(ref _accountNo, value); 
            }
		}

        [JsonIgnore]
        public string Summary
        {
            get
            {
                return Bank + ", " + AccountType + ", " + AccountNo;
            }
        }
    }
}