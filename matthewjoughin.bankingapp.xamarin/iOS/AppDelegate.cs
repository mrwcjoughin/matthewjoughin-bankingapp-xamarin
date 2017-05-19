using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

using matthewjoughin.bankingapp.xamarin.iOS.Providers;

namespace matthewjoughin.bankingapp.xamarin.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            DependencyService.Register<MicrosoftAESEncryptionProvider>();

            LoadApplication(new App());

			Xamarin.IQKeyboardManager.SharedManager.Enable = true;
			Xamarin.IQKeyboardManager.SharedManager.EnableAutoToolbar = true;
			Xamarin.IQKeyboardManager.SharedManager.ShouldResignOnTouchOutside = true;
			Xamarin.IQKeyboardManager.SharedManager.ShouldShowTextFieldPlaceholder = true;
			Xamarin.IQKeyboardManager.SharedManager.ToolbarManageBehaviour = Xamarin.IQAutoToolbarManageBehaviour.Tag;

            return base.FinishedLaunching(app, options);
        }
    }
}