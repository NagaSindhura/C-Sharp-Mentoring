using CollectionsAndGenerics.Interfaces;

namespace CollectionsAndGenerics.Colors
{
    public class Color<T> : IColor
    {
        public int Count { get; set; }

        public string Name => typeof(T).Name;
    }
}