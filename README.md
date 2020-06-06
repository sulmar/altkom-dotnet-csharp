# .NET i język C#
Przykłady ze szkolenia Programowanie na platformie .NET za pomocą języka C#


## Klucze symetryczne

### AES

~~~ csharp
public byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            using (SymmetricAlgorithm algorithm = new AesCryptoServiceProvider())
            {
                ICryptoTransform encryptor = algorithm.CreateEncryptor(Key, IV);
                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cryptoStream))
                    {
                        sw.Write(plainText);
                    }

                    return stream.ToArray();
                }
            }
        }

        public string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            using (SymmetricAlgorithm algorithm = new AesCryptoServiceProvider())
            {
                ICryptoTransform decryptor = algorithm.CreateDecryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream(cipherText))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }
~~~

### Triple DES

~~~ csharp
public byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            using (SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider())
            {
                ICryptoTransform encryptor = algorithm.CreateEncryptor(Key, IV);
                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cryptoStream))
                    {
                        sw.Write(plainText);
                    }

                    return stream.ToArray();
                }
            }
        }

        public string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            using (SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider())
            {
                ICryptoTransform decryptor = algorithm.CreateDecryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream(cipherText))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(cs))
                {
                     return reader.ReadToEnd();
                }
            }
        }
  ~~~
