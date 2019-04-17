using System;
using System.Collections.Generic;

namespace lab09_a
{
    public static class ExtensionsMethods
    {
        public delegate void Function<T>(T x);

        

        public static void MyEach<T>(this IEnumerable<T> a, Function<T> f)
        {
            foreach (var v in a)
            {
                f(v);
            }
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> a, Func<T, bool> f)
        {
            foreach (var v in a)
            {
                if (f(v)) yield return v;
            }

        }

        
        public static T[] ToTransformedArray<T>(this IEnumerable<T> a, Func<T, T> f)
        {
            int i = 0;
            if(a==null)
            {
                return null;

            }
            foreach (var v in a)
            {
                i++;
            }
            T[] tab = new T[i];
            i = 0;
            foreach (var v in a)
            {
                tab[i] = f(v);
                i++;

            }
            return tab;
        }
    }
}
