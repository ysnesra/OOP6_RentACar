using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //microsoftun kendi cache metodu.//AddMemoryCach enjektesi microsoft otomatik yapar .core dependencye ekledik.
        IMemoryCache _memoryCache;

        //constructordan enjekte çalışmaz (wepapi->businnes->dataaccess)
        //CoreModule vardı enjekte yapılamayan yerlere enjekte için.Oraya Singleton eklenir.
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>(); //IMemoryCashe'in karşılığını verir
        }
        public void Add(string key, object value, int duration)
        {
            //TimeSpan ile zaman aralığı verilir.duration ile Cachede ne kadar süre kalacağı belirlenir
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));  
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        //bellekte böyle bir değer var mı true/false dönderen metot
        public bool IsAdd(string key)
        {
            //TyGetValue: bool tipinde true/false dönderir
            //bir değer döndürmesini istemiyorsak out _ kullanır.
            return _memoryCache.TryGetValue(key, out _); 
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        //Verilen Patterne göre Çalışma anında bellekten silme işlemini yapan metot
        //Reflection ile çalışma anındaki nesnelere müdahele eder
        public void RemoveByPattern(string pattern)
        {
            //Bellekteki EntriesCollectionu bul (MemoryCache türünde olan)
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            //Definition'ı _memoryCache olanları bul
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;

            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)  //herbir cache elemanını gezer
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            //regex değişkeninde Paterni oluşturuyoruz
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //Cache datasının içinde benim gönderdiiğim değerle eşleşen değerler varsa keysToRemove değişkenine atar
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            //keysToRemove değişkenindeki değerlerin tek tek keylerini bulup bellekten siliyorum
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
