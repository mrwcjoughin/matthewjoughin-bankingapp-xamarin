//using System;
//using System.Security.Cryptography;
////using PCLCrypto;
//using System.Text;
//using Xamarin.Forms;

//namespace matthewjoughin.bankingapp.xamarin.Security
//{
//    public class AESEncryption
//    {
//        public AESEncryption()
//        {
//        }

//        /// <summary>    
//        /// Encrypts given data using symmetric algorithm AES    
//        /// </summary>    
//        /// <param name="data">Data to encrypt</param>    
//        /// <param name="password">Password</param>    
//        /// <param name="salt">Salt</param>    
//        /// <returns>Encrypted bytes</returns>    
//        public byte[] EncryptData256(byte[] bytearraytoencrypt, string key, string iv)
//        {
//            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
//            ICryptographicKey symetricKey = aes.CreateSymmetricKey(System.Text.Encoding.UTF8.GetBytes(key));
//            var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, bytearraytoencrypt);
//            return bytes;
//            return null;
//        }

//        /// <summary>    
//        /// Decrypts given bytes using symmetric alogrithm AES    
//        /// </summary>    
//        /// <param name="data">data to decrypt</param>    
//        /// <param name="password">Password used for encryption</param>    
//        /// <param name="salt">Salt used for encryption</param>    
//        /// <returns></returns>    
//        public byte[] DecryptData256(byte[] bytearraytodecrypt, string key, string iv)
//        {
//            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
//            ICryptographicKey symetricKey = aes.CreateSymmetricKey(System.Text.Encoding.UTF8.GetBytes(key));
//            var bytes = WinRTCrypto.CryptographicEngine.Decrypt(symetricKey, bytearraytodecrypt);
//            return bytes;

//            return null;
//        }
//    }
//}