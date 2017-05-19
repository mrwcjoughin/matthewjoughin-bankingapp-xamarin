using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using matthewjoughin.bankingapp.xamarin.ViewModels;

namespace matthewjoughin.bankingapp.xamarin
{
    [XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class BeneficiaryDetailPage : ContentPage
    {
        BeneficiaryDetailViewModel viewModel;

        public BeneficiaryDetailPage(BeneficiaryDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}