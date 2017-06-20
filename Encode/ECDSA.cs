using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Encode
{
    class ECDSA
    {
        #region 数字签名

        //Alice的秘钥
        internal static CngKey aliceKeySignature;
        //Alice的公钥
        internal static byte[] alicePublicKeyBob;

        /// <summary>
        /// 产生秘钥对
        /// </summary>
        public static void CreateKey()
        {
            //使用ECDSAP256产生秘钥对
            aliceKeySignature = CngKey.Create(CngAlgorithm.ECDsaP256);
            //导出公钥
            alicePublicKeyBob = aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
            File.WriteAllText("I:\\Jack\\Encode\\Encode\\key.txt", Convert.ToBase64String(alicePublicKeyBob), Encoding.UTF8);
        }

        /// <summary>
        /// 使用私钥对数据进行数字签名
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>签名后的数据</returns>
        public static byte[] CreateSignature(byte[] data)
        {
            ECDsaCng key2 = new ECDsaCng(aliceKeySignature);
            //生成指定数据的签名，即是使用私钥进行加密
            byte[] signature = key2.SignData(data);
            //清除秘钥对
            key2.Clear();
            return signature;
        }

        /// <summary>
        /// 使用指定公钥检验签名是否对应
        /// </summary>
        /// <param name="data">未加密签名</param>
        /// <param name="signature">加密签名</param>
        /// <param name="publicKey">进行解密数字签名的的公钥</param>
        /// <returns></returns>
        public static bool VerifySignature(byte[] data, byte[] signature, byte[] publicKey)
        {
            bool flag = false;

            //封装公钥对象
            CngKey key = CngKey.Import(alicePublicKeyBob, CngKeyBlobFormat.GenericPublicBlob);

            //使用ECDSA算法封装公钥对象
            ECDsaCng signingAlg = new ECDsaCng(key);

            //使用公钥检验数字签名与原始签名是否一致
            flag = signingAlg.VerifyData(data, signature);

            return flag;
        }
        #endregion

        #region 文件加密
        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <param name="sOutputFilename"></param>
        /// <param name="sKey"></param>
        public static void EncryptFile(string sInputFilename, string sOutputFilename, string sKey)
        {
            using (FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read))
            {
                //读取文件到字节数组中
                byte[] bytearrayinput = new byte[fsInput.Length];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                fsInput.Close();

                //创建DES加密器
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = Encoding.Unicode.GetBytes(sKey);
                DES.IV = Encoding.Unicode.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();

                //创建文件流和文件加密流对象
                FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.OpenOrCreate, FileAccess.Write);
                CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

                //使用加密器写入流中
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

                //关闭流对象
                cryptostream.Close();
                fsEncrypted.Close();
            }
        }

        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <param name="sOutputFilename"></param>
        /// <param name="sKey"></param>
        public static void DecryptFile(string sInputFilename, string sOutputFilename, string sKey)
        {
            //初始化DES加解密器
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = Encoding.Unicode.GetBytes(sKey);
            DES.IV = Encoding.Unicode.GetBytes(sKey);
            using (FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read))
            {
                //创建解密器
                ICryptoTransform desdecrypt = DES.CreateDecryptor();

                //创建解密流对象
                CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);

                //创建输出流对象
                StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);

                //写入到输出流中
                fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());

                //关闭流
                fsDecrypted.Flush();
                fsDecrypted.Close();
            }
        }

        /// <summary>
        /// 生成秘钥
        /// </summary>
        public static string GenerateKey()
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return Encoding.Unicode.GetString(desCrypto.Key);
        }
        
        #endregion
    }
}
