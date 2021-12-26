using System;
using JetBrains.Annotations;

namespace FindBug.Application
{
    public static class ArrayExtension
    {
        [NotNull]
        public static T[] DShuffle<T>(this T[] array)
        {
            return array.DShuffle(new Random(Environment.TickCount));
        }

        [NotNull]
        public static T[] DShuffle<T>(this T[] array, Random r)
        {
            var size = array.Length;
            for (var i = 0; i < size; i++)
            {
                var swpIndex = r.Next(size);
                (array[i], array[swpIndex]) = (array[swpIndex], array[i]);
            }

            for (var i = size - 1; i >= 0; i--)
            {
                var swpIndex = r.Next(size);
                (array[i], array[swpIndex]) = (array[swpIndex], array[i]);
            }

            return array;
        }
    }
}