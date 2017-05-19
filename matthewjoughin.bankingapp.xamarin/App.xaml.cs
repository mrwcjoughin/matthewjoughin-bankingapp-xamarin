using System.Collections.Generic;
using matthewjoughin.bankingapp.xamarin.Security;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace matthewjoughin.bankingapp.xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public static IDictionary<string, string> LoginParameters => null;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockDataStore>();
                DependencyService.Register<MockKeyProvider>();
            }
            else
            {
                DependencyService.Register<CloudDataStore>();
                DependencyService.Register<MockKeyProvider>();
            }

            SetMainPage();
        }

        public static void SetMainPage()
        {
            //if (!UseMockDataStore && !Settings.IsLoggedIn)
            //{
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            //}
            //else
            //{
            //    GoToMainPage();
            //}
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new BeneficiarysPage())
                    {
                        Title = "Beneficiaries",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                    new NavigationPage(new LogoutPage())
                    {
                        Title = "Logout",
                        Icon = Device.OnPlatform("Logout.png", null, null)
                    },
                }
            };
        }
    }
}
