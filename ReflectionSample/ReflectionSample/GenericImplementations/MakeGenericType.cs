using System;
using System.Linq;
using ReflectionSample.Entity;
using System.Collections.Generic;

namespace ReflectionSample.GenericImplementations
{
    public class MakeGenericType
    {
        public List<T> GetGenericTypes<T>(string requestedType) where T : class
        {
            var genericClassType = typeof(GenericClass<>);

            var type = typeof(List<>).MakeGenericType(Type.GetType(requestedType));

            var genericClass = genericClassType.MakeGenericType(type);
            var genericInstance = Activator.CreateInstance(genericClass);

            var runInfo = genericClass.GetMethod("MapList", new[] { type });

            var obj = runInfo.Invoke(genericInstance, new object[] { GatData<T>().ToList() });

            return (List<T>)obj;
        }


        public IEnumerable<T> GatData<T>() where T : class
        {
            switch (typeof(T).FullName)
            {
                case "ReflectionSample.Entity.Student":
                    yield return new Student { StudentId = "s1", Name = "Student1" } as T;
                    yield return new Student { StudentId = "s2", Name = "Student2" } as T;
                    break;

                case "System.String":
                    yield return "one" as T;
                    yield return "two" as T;
                    break;
            }
        }
    }
}