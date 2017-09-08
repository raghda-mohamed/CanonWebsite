using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Web;

namespace CanonCore.Utility
{
    public static class Utility
    {
        static string key = "ITQANDEVELOPMENT";
        public static bool IsSalaryGenerating = false;


        public enum SalaryType
        {
            EmployeeSalaries = 1,
            EmployeeInsuranceSalaries = 2
        };
        public enum PunishmentDeductionType
        {
            [Description("خصم")]
            Deduction = 1,
            [Description("فصل")]
            Fire = 2,
            [Description("إنذار كتابى")]
            WrittenLetter = 3,
            [Description("إبلاغ الجهات المعنية")]
            InformConcernedAuthorities = 4
        }
        public enum PunishmentDeductionTypeEn
        {
            [Description("Deduction")]
            Deduction = 1,
            [Description("Fire")]
            Fire = 2,
            [Description("Written Letter")]
            WrittenLetter = 3,
            [Description("Inform Concerned Authorities")]
            InformConcernedAuthorities = 4
        }

        public static string Decryption(string Credential)
        {
            try
            {
                #region Convert hex string to byte[]
                byte[] encryptedTextBytes = Enumerable.Range(0, Credential.Length)
                          .Where(x => x % 2 == 0)
                          .Select(x => Convert.ToByte(Credential.Substring(x, 2), 16))
                          .ToArray();
                #endregion
                MemoryStream MemoryStream = new MemoryStream();
                SymmetricAlgorithm SymmetricAlgorithm = SymmetricAlgorithm.Create();

                byte[] keyByte = Encoding.ASCII.GetBytes(key);
                CryptoStream cs = new CryptoStream(MemoryStream, SymmetricAlgorithm.CreateDecryptor(keyByte, keyByte), CryptoStreamMode.Write);
                cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                cs.Close();
                return Encoding.UTF8.GetString(MemoryStream.ToArray());
            }
            catch (Exception Ex)
            {
               // Utility.LogError(Ex, "Sarah", "Decryption");
                return "";
            }
        }
        //public static void LogError(Exception ex, string DeveloperName, string Description)
        //{
        //    var exception = new Exception(DeveloperName + " / " + Description, ex);
        //    Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
        //}
        public static string ConvertNumerals(this string input)
        {
            if (new string[] {"ar-EG" }
                  .Contains(Thread.CurrentThread.CurrentCulture.Name))
            {
                return input.Replace('0', '\u0660')
               .Replace('1', '\u0661')
               .Replace('2', '\u0662')
               .Replace('3', '\u0663')
               .Replace('4', '\u0664')
               .Replace('5', '\u0665')
               .Replace('6', '\u0666')
               .Replace('7', '\u0667')
               .Replace('8', '\u0668')
               .Replace('9', '\u0669');
            }
            else return input;
        }
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
        public static string GetEnumDescription(Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch (Exception Ex)
            {
                //Utility.LogError(Ex, "", "GetEnumDescription");
                return string.Empty;
            }
        }
        public static string Encryption(string UserID)
        {
            try
            {
                string EncryptedID = "";
                byte[] clearTextBytes = Encoding.UTF8.GetBytes(UserID);
                System.Security.Cryptography.SymmetricAlgorithm SymmetricAlgorithm = SymmetricAlgorithm.Create();
                MemoryStream MemoryStream = new MemoryStream();

                byte[] keyByte = Encoding.ASCII.GetBytes(key);
                CryptoStream cs = new CryptoStream(MemoryStream, SymmetricAlgorithm.CreateEncryptor(keyByte, keyByte), CryptoStreamMode.Write);
                cs.Write(clearTextBytes, 0, clearTextBytes.Length);
                cs.Close();
                #region Convert byte[] to hex string
                byte[] byteArray = MemoryStream.ToArray();
                var hex = new StringBuilder(byteArray.Length * 2);
                foreach (var b in byteArray)
                    hex.AppendFormat("{0:x2}", b);
                #endregion
                EncryptedID = hex.ToString();
                return EncryptedID;
            }
            catch (Exception ex)
            {
                //Utility.LogError(ex, "Reem", "Encryption");
                return string.Empty;
            }
        }
    
    }
}
