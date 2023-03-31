using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    //JWT İÇİN
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;// Jwt a gönderecek istek yapınca Her istek için bir threat(HttpContext) oluşur

        public SecuredOperation(string roles)
        {
            //Aspectleri Attribute şeklinde tanımlarken rolleri virgülle ayırarak veriyoruz
            //Split ile , karakterine gelince _roles arrayine atıyor.Kaç rol verildiyse _roles de tutuyor
            //ServiceTool-> Projemizde aspectlerde İnjection yapmamızı sağlar.Injection alt yapımızı okuyabilmemizi sağlayan araçtır
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
           
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //Kullanıcının ClaimRoles'lerini bul 
            //Claimlerinin içinde ilgili rol varsa return et yani metotu çalıştırmaya devam et demek
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
