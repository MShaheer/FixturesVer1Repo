using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FixturesVer1.Utility
{
    public class Cryptography
    {
        #region Object initializations & references

        private static MD5 md5Object = new MD5CryptoServiceProvider();
        private static TripleDES desObject = new TripleDESCryptoServiceProvider();
        private static StringBuilder strFixKey;

        #endregion

        #region Methods

        public static string Encryption(string p_strPlainText)
        {
            strFixKey = new StringBuilder();
            strFixKey.Append("Fixtures,");
            strFixKey.Append("Real Estate Buying Rental Sharing,");
            

            desObject.Key = md5Object.ComputeHash(Encoding.Unicode.GetBytes(strFixKey.ToString()));
            desObject.IV = new byte[desObject.BlockSize / 8];
            ICryptoTransform ctObject = desObject.CreateEncryptor();

            byte[] bInput = Encoding.Unicode.GetBytes(p_strPlainText);
            byte[] bBuffer = ctObject.TransformFinalBlock(bInput, 0, bInput.Length);

            return Convert.ToBase64String(bBuffer);

        }

        public static string Decryption(string p_strCipherText)
        {
            strFixKey = new StringBuilder();
            strFixKey.Append("Fixtures,");
            strFixKey.Append("Real Estate Buying Rental Sharing,");
           

            desObject.Key = md5Object.ComputeHash(Encoding.Unicode.GetBytes(strFixKey.ToString()));
            desObject.IV = new byte[desObject.BlockSize / 8];

            ICryptoTransform dtObject = desObject.CreateDecryptor();

            byte[] bInput = Convert.FromBase64String(p_strCipherText);
            byte[] bOutput = dtObject.TransformFinalBlock(bInput, 0, bInput.Length);

            return Encoding.Unicode.GetString(bOutput);
        }

        #endregion
    }
}