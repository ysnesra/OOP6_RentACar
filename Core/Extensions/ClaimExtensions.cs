using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    //Claimleri, Extensions metot içinde oluşturuldu -> JwtHelper.cs ında kullanırken buradaki metot isimleriyle çağrılır
    public static class ClaimExtensions
    {
        //AddEmail metotu önce neyi extent edecek onu yazarız -> this ICollection<Claim> claims
        //prametremiz de -> string email

        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            //Jwt nin kendi isimlendirmesinde tutarız JwtRegisteredClaimNames.Email
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            //gönderilen roles leri listeye çevir.Foreach ile tek tek dolaş herbir rolü Claim ekle 
        }
    }
}