﻿using System;
using System.Security.Cryptography;
using matthewjoughin.bankingapp.xamarin.Interfaces;

namespace matthewjoughin.bankingapp.xamarin.MacOS.Providers
{
    public class MicrosoftAESEncryptionProvider: IAESEncryptionProvider
    {
		public byte[] EncryptData256(byte[] bytearraytoencrypt, string key, string iv)
		{
            System.Security.Cryptography.AesCryptoServiceProvider dataencrypt = new System.Security.Cryptography.AesCryptoServiceProvider();

            //Block size : Gets or sets the block size, in bits, of the cryptographic operation.  
            dataencrypt.BlockSize = 128;
            //KeySize: Gets or sets the size, in bits, of the secret key  
            dataencrypt.KeySize = 256;
            //Key: Gets or sets the symmetric key that is used for encryption and decryption.  
            dataencrypt.Key = System.Text.Encoding.UTF8.GetBytes(key);
            //IV : Gets or sets the initialization vector (IV) for the symmetric algorithm  SALT
            dataencrypt.IV = System.Text.Encoding.UTF8.GetBytes(iv);
            //Padding: Gets or sets the padding mode used in the symmetric algorithm  
            dataencrypt.Padding = PaddingMode.PKCS7;
            //Mode: Gets or sets the mode for operation of the symmetric algorithm  
            dataencrypt.Mode = CipherMode.CBC;
            //Creates a symmetric AES encryptor object using the current key and initialization vector (IV).  
            ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);
            //TransformFinalBlock is a special function for transforming the last block or a partial block in the stream.   
            //It returns a new array that contains the remaining transformed bytes. A new array is returned, because the amount of   
            //information returned at the end might be larger than a single block when padding is added.  
            byte[] encrypteddata = crypto1.TransformFinalBlock(bytearraytoencrypt, 0, bytearraytoencrypt.Length);
            crypto1.Dispose();
            //return the encrypted data  
            return encrypteddata;
        }

		public byte[] DecryptData256(byte[] bytearraytodecrypt, string key, string iv)
		{
            System.Security.Cryptography.AesCryptoServiceProvider keydecrypt = new System.Security.Cryptography.AesCryptoServiceProvider();
            keydecrypt.BlockSize = 128;
            keydecrypt.KeySize = 256;
            keydecrypt.Key = System.Text.Encoding.UTF8.GetBytes(key);
            keydecrypt.IV = System.Text.Encoding.UTF8.GetBytes(iv);
            keydecrypt.Padding = PaddingMode.PKCS7;
            keydecrypt.Mode = CipherMode.CBC;
            ICryptoTransform crypto1 = keydecrypt.CreateDecryptor(keydecrypt.Key, keydecrypt.IV);

            byte[] returnbytearray = crypto1.TransformFinalBlock(bytearraytodecrypt, 0, bytearraytodecrypt.Length);
            crypto1.Dispose();
            return returnbytearray;
        }
	}
}