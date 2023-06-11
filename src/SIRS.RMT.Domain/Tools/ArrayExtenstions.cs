using System;
using System.Linq;

namespace SIRS.RMT.Domain.Tools
{
    public static class ArrayExtensions
    {
        public static void Shuffle<T>(this T[] array)
        {
            var rng = new Random();
            var n = array.Length;
            while (n > 1)
            {
                var k = rng.Next(n--);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        public static bool CompareArrays<T>(T[] array1, T[] array2)
        {
            return array1.SequenceEqual(array2);
        }
    }
}