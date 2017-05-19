# matthewjoughin-bankingapp-xamarin

Objective
Create a demo banking app that runs on all available platforms supported by Xamarin.Forms

Goals
Prove that it can be done and run on iOS, Android, MacOS, and UWP (Universal Windows Platform), all sharing the same common code and UI’s, so that features can be rapidly added to all platforms by a much smaller team of developers than used presently.

Solution
Used latest Xamarin.Forms beta package to create the project accordingly (so that we gained MacOS and UWP which are in beta) and execute on this goal

Project Outline
Created the solution and added functionality for basic starting use case for a banking app: 

Logging in
Viewing and adding of Beneficiaries
A backend was not added, only a mock one, as it wasn’t necessary to prove that one Xamarin.Forms app could run on all the target platforms.

Running the code:
On Windows:
You will need Visual Studio 2017 (any edition) or higher, with the mobile features ticked/installed  - you can get this from Microsoft’s website
This will allow you to run the UWP natively
This will allow you to run the Android project through the emulator or if you have a physical device attached
This will allow you to run the iOS project if you have an iPhone connected and a Mac machine on the network to act as the build machine

On MacOS:
You will need the latest version of XCode installed - you can get this from Apple’s website or from the Apple MacOS App Store
You will need the latest version of Xamarin or Visual Studio for Mac installed - you need to choose the Alpha update channel if you want the access to run the MacOS project - as it's currently in beta as of the date of this readme

On either platform, whichever IDE you are in, you need to set the startup project to which ever platform project you wish to run to run that platform

Testing the Demo:
Login with any username or password - as long as each is at least 5 characters
