// -----------------------------------------------------------------------
// <copyright file="Crypto.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Barclays.Treasury.Cryptography
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// A Class to help with encrypting and decrypting strings.
    /// Unashamedly stolen from http://stackoverflow.com/questions/202011/encrypt-decrypt-string-in-net and tidied by Steve Smith
    /// </summary>
    public class Crypto
    {
        /// <summary>
        /// The key that is used in the en/de-crypt process.
        /// </summary>
        private const string Key = "o6806642kbM7c5";
            
        public static string Encrypt(string plainString, bool useHashing = false)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(plainString);
            
            if (useHashing)
            {
                keyArray = GetKeyArrayUsingMD5Provider(Key);
            }
            else
            {
                keyArray = Encoding.UTF8.GetBytes(Key);
            }

            var tripleDesCryptoServiceProvider = GetTripleDesProvider(keyArray);

            var cryptoTransform = tripleDesCryptoServiceProvider.CreateEncryptor();
            var resultArray = cryptoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tripleDesCryptoServiceProvider.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>The decrypt method.</summary>
        /// <param name="encryptedString">The encrypted string.</param>
        /// <param name="useHashing">The use hashing flag (default=false), uses MD5 hashing if true.</param>
        /// <returns>The plain <see cref="string"/>.</returns>
        public static string Decrypt(string encryptedString, bool useHashing = false)
        {
            byte[] keyArray;
            byte[] toDecryptArray = Convert.FromBase64String(encryptedString);
            
            if (useHashing)
            {
                keyArray = GetKeyArrayUsingMD5Provider(Key);
            }
            else
            {
                keyArray = Encoding.UTF8.GetBytes(Key);
            }

            var tripleDesCryptoServiceProvider = GetTripleDesProvider(keyArray);

            var cryptoTransform = tripleDesCryptoServiceProvider.CreateDecryptor();
            byte[] resultArray = cryptoTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

            tripleDesCryptoServiceProvider.Clear();

            return Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
        }

        /// <summary>Get a new <see cref="TripleDESCryptoServiceProvider"/>.</summary>
        /// <param name="keyArray">The key array.</param>
        /// <returns>The <see cref="TripleDESCryptoServiceProvider"/></returns>
        private static TripleDESCryptoServiceProvider GetTripleDesProvider(byte[] keyArray)
        {
            return new TripleDESCryptoServiceProvider
                       {
                           Key = keyArray,
                           Mode = CipherMode.ECB,
                           Padding = PaddingMode.PKCS7
                       };
        }

        /// <summary>Get key array using md5 provider.</summary>
        /// <param name="key">The key.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static byte[] GetKeyArrayUsingMD5Provider(string key)
        {
            var md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] keyArray = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
            md5CryptoServiceProvider.Clear();
            return keyArray;
        }
    }
}
