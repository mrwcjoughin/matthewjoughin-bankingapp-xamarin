using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matthewjoughin.bankingapp.xamarin
{
    public class MockDataStore : IDataStore<Beneficiary>
    {
        bool isInitialized;
        List<Beneficiary> beneficiarys;

        public MockDataStore()
        {
            beneficiarys = new List<Beneficiary>();
            var _beneficiarys = new List<Beneficiary>
            {
                new Beneficiary { Id = Guid.NewGuid().ToString(), Name = "John Doe", Bank="FNB", AccountType="Cheque", AccountNo="34523453"},
                new Beneficiary { Id = Guid.NewGuid().ToString(), Name = "Jane Doe", Bank="FNB", AccountType="Savings", AccountNo="45346343"},
            };

            foreach (Beneficiary beneficiary in _beneficiarys)
            {
                beneficiarys.Add(beneficiary);
            }
        }

        public async Task<bool> AddBeneficiaryAsync(Beneficiary beneficiary)
        {
            beneficiarys.Add(beneficiary);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateBeneficiaryAsync(Beneficiary beneficiary)
        {
            var _beneficiary = beneficiarys.Where((Beneficiary arg) => arg.Id == beneficiary.Id).FirstOrDefault();
            beneficiarys.Remove(_beneficiary);
            beneficiarys.Add(beneficiary);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteBeneficiaryAsync(string id)
        {
            var _beneficiary = beneficiarys.Where((Beneficiary arg) => arg.Id == id).FirstOrDefault();
            beneficiarys.Remove(_beneficiary);

            return await Task.FromResult(true);
        }

        public async Task<Beneficiary> GetBeneficiaryAsync(string id)
        {
            return await Task.FromResult(beneficiarys.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Beneficiary>> GetBeneficiarysAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(beneficiarys);
        }
    }
}
