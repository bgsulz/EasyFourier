using System.Collections.Generic;
using System.Numerics;

namespace EasyFourier
{
    public static class CollectionFormatter
    {
        internal static IEnumerable<T> GetEnumerableRange<T>(this IList<T> list, int offset, int length)
        {
            for (int i = offset; i < length; i++) yield return list[i];
        }
        
        internal static IList<T> GetRange<T>(this IList<T> list, int offset, int length)
        {
            IList<T> result = new List<T>();
            for (int i = offset; i < length; i++)
                result.Add(list[i]);
            return result;
        }

        internal static List<Complex> ToComplexList(this IList<double> self)
        {
            List<Complex> result = new List<Complex>();
            
            foreach (var item in self) 
                result.Add(new Complex(item, 0));
            
            return result;
        }

        internal static List<Complex> ToComplexList(this IList<float> self)
        {
            List<Complex> result = new List<Complex>();
            
            foreach (var item in self) 
                result.Add(new Complex(item, 0));
            
            return result;
        }
    }
}