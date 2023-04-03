using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    //Patterne göre silme işlemi 
    //Datamız bozuldugu zaman (ekleme silme güncelleme) oldugu zaman çalışır.
    //Veriyi manipüle eden metotlarına CacheRemove uygulanır.
    //Cacheyi gereksiz doldurmamak için.METOT BAŞARILI OLUR İSE (OnSuccess metotu)

    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        //OnSuccess metotunu override ederiz böylece; metot başarı olursa [CacheRemoveAspect] Aspectini çalıştırır
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
