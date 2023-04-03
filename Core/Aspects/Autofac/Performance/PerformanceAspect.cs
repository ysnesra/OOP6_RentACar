using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;   //geçen süre (5sn gibi)
        private Stopwatch _stopwatch; //TİMER,kronometre (metot ne kadar sürecek)
        //CoreModule'a Stopwatch implementasyonu eklendi

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();  //Stopwatch'ın karşılığı olan somut sınıfı ile injection yapar
        }

        //OnBefore ile Metotun önünde kronometre başlar
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        //OnAfter ile Metot bittiğinde o zamana kadar geçen süreyi hesaplayıp  
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)//Geçen süre > 5snden büyükse
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
                //Console a log olarak yazar. Yada mail olarak da gönderir 
            }
            _stopwatch.Reset();
        }
    }
}
