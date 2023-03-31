using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //password verip -> passwordHash,passwordSalt oluşturcak metot
        //out keyword'ü, passwordHash ve passwordSalt değişkenlerinin metot içerisinde oluşturulacağını ve metottan döndürüleceğini gösterir. Yani, bu değişkenler, metotun dışındaki kod tarafından tanımlanmak zorunda değildir.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //SHA1 şifreleme algoritmasını kullanarak bir hmac nesnesi oluşturur.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {               
                //Algoritemanın değişmeyen anahtarı. Her kullanıcı için başka bir key oluşturur
                passwordSalt = hmac.Key;

                //Encoding.UTF8.GetBytes(password) -> password stringinin byte dizisine dönüştürür
                //ComputeHash ile byte dizisini şifreler 
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //PasswordHash'i doğrulayan metot
        //passwordHash, passwordSalt değerleri veritabanından gelen değerler
        //Kullanıcı sisteme 2. kez girerken parolasını giriyor.Bu parolayı (veritanbanındaki passwordSaltı kullanarak) tekrar hashleyip -> veritabanındaki PasswordHash ile karşılaştıran metot
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//saltı kullanıyoruz burada.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//aynı şekilde birdaha oluşturduk.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])  //hesaplananhash'in i. değeri eşitmi veritabanından gönderilen hashin i. değerine 
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

