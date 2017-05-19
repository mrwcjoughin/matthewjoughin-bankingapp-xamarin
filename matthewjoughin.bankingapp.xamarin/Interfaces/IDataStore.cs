using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace matthewjoughin.bankingapp.xamarin
{
    public interface IDataStore<T>
    {
        Task<bool> AddBeneficiaryAsync(T beneficiary);
        Task<bool> UpdateBeneficiaryAsync(T beneficiary);
        Task<bool> DeleteBeneficiaryAsync(string id);
        Task<T> GetBeneficiaryAsync(string id);
        Task<IEnumerable<T>> GetBeneficiarysAsync(bool forceRefresh = false);
    }
}
