using System;
using PCLCrypto;
using matthewjoughin.bankingapp.xamarin.Interfaces;

namespace matthewjoughin.bankingapp.xamarin.UWP.Providers
{
    public class PCLCryptoEncryptionProvider: IAESEncryptionProvider
    {
		public byte[] EncryptData256(byte[] bytearraytoencrypt, string key, string iv)
		{
            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
            ICryptographicKey symetricKey = aes.CreateSymmetricKey(System.Text.Encoding.UTF8.GetBytes(key));
            var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, bytearraytoencrypt);
            return bytes;
        }

        public byte[] DecryptData256(byte[] bytearraytodecrypt, string key, string iv)
		{
            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
            ICryptographicKey symetricKey = aes.CreateSymmetricKey(System.Text.Encoding.UTF8.GetBytes(key));
            var bytes = WinRTCrypto.CryptographicEngine.Decrypt(symetricKey, bytearraytodecrypt);
            return bytes;
        }
    }
}