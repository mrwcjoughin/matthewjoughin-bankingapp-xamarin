using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace matthewjoughin.bankingapp.xamarin.Helpers
{
    public class OnPlatformExtended<T> : OnPlatform<T>
    {
        public T Other { get; set; }

        public T Windows { get; set; }

        public static implicit operator T(OnPlatformExtended<T> onPlatform)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                return onPlatform.Windows;
            }

            if (Device.OS == TargetPlatform.Other)
            {
                return onPlatform.Other;
            }

            return (OnPlatform<T>)onPlatform;
        }
    }
}