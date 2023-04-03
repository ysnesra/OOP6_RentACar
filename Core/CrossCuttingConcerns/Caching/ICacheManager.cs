using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key); 
        void Add(string key, object value, int duration); 
    
        bool IsAdd(string key); 
        void Remove(string key);    

        //Belli bir Pattern göre silecek metot (Yani ; içinde Get,Category ismi geçen metotları silmesi) 
        void RemoveByPattern (string pattern);  

    }
}
