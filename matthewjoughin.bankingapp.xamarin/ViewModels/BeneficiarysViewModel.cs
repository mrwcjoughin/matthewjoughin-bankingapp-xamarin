using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace matthewjoughin.bankingapp.xamarin.ViewModels
{
    public class BeneficiarysViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Beneficiary> Beneficiarys { get; set; }
        public Command LoadBeneficiarysCommand { get; set; }

        public BeneficiarysViewModel()
        {
            Title = "Beneficiaries";
            Beneficiarys = new ObservableRangeCollection<Beneficiary>();
            LoadBeneficiarysCommand = new Command(async () => await ExecuteLoadBeneficiarysCommand());

            MessagingCenter.Subscribe<NewBeneficiaryPage, Beneficiary>(this, "AddBeneficiary", async (obj, beneficiary) =>
            {
                var _beneficiary = beneficiary as Beneficiary;
                Beneficiarys.Add(_beneficiary);
                await DataStore.AddBeneficiaryAsync(_beneficiary);
            });
        }

        async Task ExecuteLoadBeneficiarysCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Beneficiarys.Clear();
                var beneficiarys = await DataStore.GetBeneficiarysAsync(true);
                Beneficiarys.AddRange(beneficiarys);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load beneficiarys.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
