using System;
using System.Security.Cryptography;
using System.Text;

internal class XwormUnpacker
{
    public static string Mutex = "XWorm Mutex Here";

    public static object Decrypt(string input)
    {

        // # OLD
        RijndaelManaged rijndaelManaged = new RijndaelManaged();
        MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
        byte[] array = new byte[32];
        byte[] array2 = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(Mutex));
        Array.Copy(array2, 0, array, 0, 16);
        Array.Copy(array2, 0, array, 15, 16);
        rijndaelManaged.Key = array;
        rijndaelManaged.Mode = CipherMode.ECB;
        ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
        byte[] array3 = Convert.FromBase64String(input);
        return Encoding.UTF8.GetString(cryptoTransform.TransformFinalBlock(array3, 0, array3.Length));


    }

    static void Main(string[] args)
    {
        var Host = "Host Here";
        var Port = "Port Here";
        //var KEY = "Di1EUQaCkxj4NsuYE84xZA==";
        //var SPL = "pYRh1ZaEpqOA/SOh8SP6CA==";
        //var USBNM = "ZpMt/fhAbZH/LD/BPRS9HQ==";
        Console.WriteLine(Decrypt(Host));
        Console.WriteLine(Decrypt(Port));
        //Console.WriteLine(Decrypt(KEY));
        //Console.WriteLine(Decrypt(SPL));
        //Console.WriteLine(Decrypt(USBNM));

        Console.ReadLine    ();
    }
}