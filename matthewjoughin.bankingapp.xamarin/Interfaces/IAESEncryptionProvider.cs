using System;
namespace matthewjoughin.bankingapp.xamarin.Interfaces
{
    public interface IAESEncryptionProvider
    {
        byte[] EncryptData256(byte[] bytearraytoencrypt, string key, string iv);

        byte[] DecryptData256(byte[] bytearraytodecrypt, string key, string iv);
    }
}