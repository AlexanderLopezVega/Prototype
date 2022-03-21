using System.Collections.Generic;

namespace com.alexlopezvega.prototype
{
    public static class CSharpExtensions
    {
        public static U Emplace<T, U>(this Dictionary<T, U> map, T key, U emplaceValue) where U : new()
        {
            if (!map.TryGetValue(key, out U value))
            {
                value = emplaceValue;
                map.Add(key, value);
            }

            return value;
        }
    }
}
