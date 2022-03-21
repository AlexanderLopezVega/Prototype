using System.Collections.Generic;

namespace com.alexlopezvega.prototype
{
    public static class CSharpExtensions
    {
        public static U Emplace<T, U>(this Dictionary<T, U> map, T key) where U : new()
        {
            if (!map.TryGetValue(key, out U value))
            {
                value = new U();
                map.Add(key, value);
            }

            return value;
        }
    }
}
