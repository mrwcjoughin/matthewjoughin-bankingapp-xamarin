using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace matthewjoughin.bankingapp.xamarin.ViewModels
{
    public class BeneficiaryDetailViewModel : BaseViewModel
    {
        public Beneficiary Beneficiary { get; set; }
        private string _name = string.Empty;
        private string _accountNo = string.Empty;
        private string _accountType = string.Empty;
        private string _bank = string.Empty;

        public BeneficiaryDetailViewModel(Beneficiary beneficiary = null)
        {
            Name = beneficiary.Name;
            AccountNo = beneficiary.AccountNo;
            AccountType = beneficiary.AccountType;
            Bank = beneficiary.Bank;

            Title = "Beneficiary";

            Beneficiary = beneficiary;
        }

		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		public string AccountNo
		{
			get { return _accountNo; }
			set { SetProperty(ref _accountNo, value); }
		}

		public string AccountType
		{
			get { return _accountType; }
			set { SetProperty(ref _accountType, value); }
		}

		public string Bank
		{
			get { return _bank; }
			set { SetProperty(ref _bank, value); }
		}
    }
}