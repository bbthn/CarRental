using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {   
        public virtual void OnBefore(IInvocation vocation) { }
        public virtual void OnAfter(IInvocation vocation) { }
        public virtual void OnException(IInvocation vocation,System.Exception e) { }
        public virtual void OnSuccess(IInvocation vocation) { }


        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();

            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                
                if(isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);

        }
    }
}
