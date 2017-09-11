using System;
using System.Reflection;

namespace AppDomainSample
{
    public class ThrirdPartyDomainLoader : MarshalByRefObject
    {
        private Assembly _assembly;

        public void MethodInvoker(string dllpath, string className, string methodName, params object[] parameters)
        {
            var assm = Assembly.LoadFile(dllpath);

            var type1 = assm.GetType(className);

            var genericInstance = Activator.CreateInstance(type1);

            var method = type1.GetMethod(methodName);

            try
            {
                var isSuccess = (bool)method.Invoke(genericInstance, parameters);

                Console.WriteLine(isSuccess ? "File Created successfully" : "Unsuccessfull File Creation");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}