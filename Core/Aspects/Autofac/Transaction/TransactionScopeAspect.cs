using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation) //invocation: metot 
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();    //metotu çalıştırır
                    transactionScope.Complete();  //scope'u tamamla
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();  //metot hata alırsa scope'u iptal et
                    throw;
                }
            }
        }
    }
}