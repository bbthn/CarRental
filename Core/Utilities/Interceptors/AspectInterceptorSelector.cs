using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var ClassAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var MethodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            ClassAttributes.AddRange(MethodAttributes);

            return ClassAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
