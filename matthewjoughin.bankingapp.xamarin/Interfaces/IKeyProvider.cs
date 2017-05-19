using System;
using System.Threading.Tasks;

namespace matthewjoughin.bankingapp.xamarin.Interfaces
{
    public interface IKeyProvider
    {
        Task<string> Key();

		Task<string> Salt();

        //IKeyProvider SharedInstance
        //{
        //    get;
        //}
    }
}