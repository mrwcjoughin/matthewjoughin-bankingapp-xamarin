using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace matthewjoughin.bankingapp.xamarin
{
    public class CloudDataStore : IDataStore<Beneficiary>
    {
        HttpClient client;
        IEnumerable<Beneficiary> beneficiarys;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            beneficiarys = new List<Beneficiary>();
        }

        public async Task<IEnumerable<Beneficiary>> GetBeneficiarysAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/beneficiary");
                beneficiarys = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Beneficiary>>(json));
            }

            return beneficiarys;
        }

        public async Task<Beneficiary> GetBeneficiaryAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/beneficiary/{id}");
                beneficiarys = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Beneficiary>>(json));
            }

            return null;
        }

        public async Task<bool> AddBeneficiaryAsync(Beneficiary beneficiary)
        {
            if (beneficiary == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedBeneficiary = JsonConvert.SerializeObject(beneficiary);

            var response = await client.PostAsync($"api/beneficiary", new StringContent(serializedBeneficiary, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> UpdateBeneficiaryAsync(Beneficiary beneficiary)
        {
            if (beneficiary == null || beneficiary.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedBeneficiary = JsonConvert.SerializeObject(beneficiary);
            var buffer = System.Text.Encoding.UTF8.GetBytes(serializedBeneficiary);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/beneficiary/{beneficiary.Id}"), byteContent);

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> DeleteBeneficiaryAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/beneficiary/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}