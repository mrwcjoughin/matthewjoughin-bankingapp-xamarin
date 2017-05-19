using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace matthewjoughin.bankingapp.xamarin
{
    [XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class NewBeneficiaryPage : ContentPage
    {
        public Beneficiary Beneficiary { get; set; }

        public NewBeneficiaryPage()
        {
            InitializeComponent();

            Beneficiary = new Beneficiary
            {
                //Name = "",
                //Description = "This is a nice description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddBeneficiary", Beneficiary);
            await Navigation.PopToRootAsync();
        }
    }
}
