using System.Security.Cryptography;
using System.Text;

namespace TechReciclyingAlpha.Helper
{   
   public static class Criptografias
   {
        //        public static string GerarHash(this string valor)
        //        {
        //            var hash = SHA1.Create();
        //            var encoding = new ASCIIEncoding();
        //            var array = encoding.GetBytes(valor);   

        //            array = hash.ComputeHash(array);

        //            var strHexa = new StringBuilder();

        //            foreach (char item in array)
        //            {
        //                strHexa.Append(item.ToString("x2"));    
        //            }

        //            return strHexa.ToString();  
        //        }


        public static string CriarPasswordHash(this string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                senha = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return senha;
        }

    }
}


