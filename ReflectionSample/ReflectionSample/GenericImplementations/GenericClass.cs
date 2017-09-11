namespace ReflectionSample.GenericImplementations
{
    public class GenericClass<TType> where TType : class
    {
        public TType MapList(TType items)
        {
            return items;
        }
    }
}