using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    //AccessToken:erişim anahtarı
    public class AccessToken
    {
        public string Token { get; set; }  //jwt değerimiz
        public DateTime Expiration { get; set; }   //token bitiş zamanı
    }
}
