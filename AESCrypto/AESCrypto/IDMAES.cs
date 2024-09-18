
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System.Text;

namespace AESCrypto
{
    public class IDMAES
    {
        // Change these keys       

        public static readonly int NonceBitSize = 128;
        public static readonly int MacBitSize = 128;

        //GCM Encryption
        public static string EncryptString_Aes(string keyString, string secretMessage)
        {
            try
            {
                if (keyString != null)
                {

                    var plainText = Encoding.UTF8.GetBytes(secretMessage);
                    byte[] key = Convert.FromBase64String(keyString);
                    var cipherText = Encrypt(plainText, key);

                    // Return encrypted data    
                    return Convert.ToBase64String(cipherText);
                }

                return secretMessage;
            }
            catch 
            {
                throw;
            }                       
            
        }

        private static byte[] Encrypt(byte[] secretMessage, byte[] key)
        {
            try
            {
                //Using random nonce large enough not to repeat
                //var nonce = new byte[NonceBitSize / 8];
                //Random.NextBytes(nonce, 0, nonce.Length);

                var nonce = Enumerable.Repeat((byte)0x20, 16).ToArray();

                var cipher = new GcmBlockCipher(new AesEngine());
                var parameters = new AeadParameters(new KeyParameter(key), MacBitSize, nonce);
                cipher.Init(true, parameters);

                //Generate Cipher Text With Auth Tag
                var cipherText = new byte[cipher.GetOutputSize(secretMessage.Length)];
                var len = cipher.ProcessBytes(secretMessage, 0, secretMessage.Length, cipherText, 0);
                cipher.DoFinal(cipherText, len);

                //Assemble Message
                using (var combinedStream = new MemoryStream())
                {
                    using (var binaryWriter = new BinaryWriter(combinedStream))
                    {
                        //Prepend Nonce
                        binaryWriter.Write(nonce);
                        //Write Cipher Text
                        binaryWriter.Write(cipherText);
                    }
                    return combinedStream.ToArray();
                }
            }
            catch 
            {
                throw;
            }            
            
        }

        public static string DecryptString_Aes(string keyString, string EncryptedString)
        {
            try
            {
                if (EncryptedString.Length < 40)
                {
                    var check = EncryptedString;
                    return EncryptedString;
                }
                
                if (EncryptedString.Length < 40)
                {
                    return EncryptedString;

                }
                byte[] ciphertext = Convert.FromBase64String(EncryptedString);
                var plaintextBytes = new byte[ciphertext.Length];
                if (keyString != null)
                {
                    var cipherText = Convert.FromBase64String(EncryptedString);
                    byte[] key = Convert.FromBase64String(keyString);
                    var plaintext = Decrypt(cipherText, key);
                    return plaintext == null ? EncryptedString : Encoding.UTF8.GetString(plaintext);
                }

                return EncryptedString;
            }
            catch 
            {
                throw;
            }
            
        }

        private static byte[] Decrypt(byte[] encryptedMessage, byte[] key)
        {
            try
            {
                using (var cipherStream = new MemoryStream(encryptedMessage))
                using (var cipherReader = new BinaryReader(cipherStream))
                {
                    //Grab Nonce
                    var nonce = cipherReader.ReadBytes(NonceBitSize / 8);

                    var cipher = new GcmBlockCipher(new AesEngine());
                    var parameters = new AeadParameters(new KeyParameter(key), MacBitSize, nonce);
                    cipher.Init(false, parameters);

                    //Decrypt Cipher Text
                    var cipherText = cipherReader.ReadBytes(encryptedMessage.Length - nonce.Length);
                    var plainText = new byte[cipher.GetOutputSize(cipherText.Length)];

                    try
                    {
                        var len = cipher.ProcessBytes(cipherText, 0, cipherText.Length, plainText, 0);
                        cipher.DoFinal(plainText, len);

                    }
                    catch (InvalidCipherTextException)
                    {
                        //Return null if it doesn't authenticate
                        return null;
                    }
                    return plainText;
                }
            }
            catch
            {
                throw;
            }            

        }
    }
}