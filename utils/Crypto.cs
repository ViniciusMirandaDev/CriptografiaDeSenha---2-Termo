using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NyousTarde.utils
{
    // Definimos como static para instanciá-la em qualquer lugar da aplicação
    public static class Crypto
    {
        // O salt é colocado aqui(o Salt deixa ainda mais seguro)
        public static string Criptografar(string Txt, string Salt)
        {
            using(SHA512 sha512Hash = SHA512.Create())
            {
                // Compute Hash, irá nos retornar um array de bytes
                //Senha + Salt
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(Salt + Txt));

                // Converterter array de bytes para string 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
