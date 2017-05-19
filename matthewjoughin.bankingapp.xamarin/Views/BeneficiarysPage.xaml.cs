﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using matthewjoughin.bankingapp.xamarin.ViewModels;

namespace matthewjoughin.bankingapp.xamarin
{
    [XamlCompilation (XamlCompilationOptions.Compile)]
    public partial class BeneficiarysPage : ContentPage
    {
        BeneficiarysViewModel viewModel;

        public BeneficiarysPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BeneficiarysViewModel();
        }

        async void OnBeneficiarySelected(object sender, SelectedItemChangedEventArgs args)
        {
            var beneficiary = args.SelectedItem as Beneficiary;
            if (beneficiary == null)
            {
                return;
            }

            await Navigation.PushAsync(new BeneficiaryDetailPage(new BeneficiaryDetailViewModel(beneficiary)));

            // Manually deselect beneficiary
            BeneficiarysListView.SelectedItem = null;
        }

        async void AddBeneficiary_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewBeneficiaryPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Beneficiarys.Count == 0)
            {
                viewModel.LoadBeneficiarysCommand.Execute(null);
            }
        }
    }
}