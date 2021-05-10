using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GunCleric.Extensions
{
    public static class ArrayExtensions
    {
        public static void Populate<T>(this IList<T> array, T value)
        {
            for (var i = 0; i<array.Count; i++)
            {
                array[i] = value;
            }
        } 

        public static void Populate<T>(this T[,] array, T value)
        {
            for (var i=0; i<array.GetLength(0); i++)
            {
                for (var j=0; j<array.GetLength(1); j++)
                {
                    array[i,j] = value;
                }
            }
        }

        public static void CopyTo<T>(this T[] oldArray, T[] newArray)
        {
            if (newArray.Length != oldArray.Length)
            {
                throw new IndexOutOfRangeException("The dimensions of the arrays do not match");
            }

            for (int i=0; i<oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }
        }

        public static void CopyTo<T>(this T[,] oldArray, T[,] newArray)
        {
            if (newArray.GetLength(0) != oldArray.GetLength(0) || newArray.GetLength(1) != oldArray.GetLength(1))
            {
                throw new IndexOutOfRangeException("The dimensions of the arrays do not match");
            }

            for (int i = 0; i < oldArray.GetLength(0); i++)
            {
                for (int j = 0; j < oldArray.GetLength(1); j++)
                {
                    newArray[i,j] = oldArray[i,j];
                }
            }
        }

        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
                throw new InvalidOperationException("Not supported for managed types.");

            if (array == null)
                throw new ArgumentNullException("array");

            int cols = array.GetUpperBound(1) + 1;
            T[] result = new T[cols];

            int size;

            if (typeof(T) == typeof(bool))
                size = 1;
            else if (typeof(T) == typeof(char))
                size = 2;
            else
                size = Marshal.SizeOf<T>();

            Buffer.BlockCopy(array, row*cols*size, result, 0, cols*size);

            return result;
        }
    }
}