using AppKit;

namespace matthewjoughin.bankingapp.xamarin.MacOS
{
    static class MainClass
    {
        static void Main(string[] args)
        {
			NSApplication.Init();
			NSApplication.SharedApplication.Delegate = new AppDelegate();
			NSApplication.Main(args);
        }
    }
}