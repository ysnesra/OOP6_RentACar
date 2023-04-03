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
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //default süresi 60dk.Değer vermezsek 60dk cache de duracak
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //ICacheMangerın Injectionını verir
        }

        //Cache olup olmadığını kontrol eden metot
        //Key oluşturuyor. key Cachede varsa ordan al yoksa veritanbanından al ve cache ekle
        public override void Intercept(IInvocation invocation)
        {
            //"namespace + class ismi . method ismi" şeklinde methodName oluştur
            //Bussines.Abstract.IProductService.GetAll()
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            //metotoun parametrelerini listeye çevirir
            var arguments = invocation.Arguments.ToList();

            //Parametre varsa methodName'e ekleyip key i oluştur
            //key değeri-> Bussines.abstract.IProductService.GetAll(2) 
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//?? varsa bunu ekle (tostring) yoksa null ekle demek.

            if (_cacheManager.IsAdd(key)) //Cache de bu key var mı
            {
                //invocation.ReturnValue ile metotdaki return'ü çalıştırmadan Cache'de olan value yu return eder
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //metotu devam ettirir, çalıştırır 
            invocation.Proceed();

            //metot çalışınca veritabanına gider veriyi getirir ve Cache e ekler
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
