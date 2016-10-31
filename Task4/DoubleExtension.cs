using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class DoubleExtension
    {

        public static string TransformDoubleToBinary(this double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            BitArray arrayBits = new BitArray(bytes);
            return TransformIntoString(arrayBits);
        }

        private static string TransformIntoString(BitArray bitArray)
        {
            char[] returnValue = new char[bitArray.Length];

            for (int i = bitArray.Length - 1, j = 0; i >= 0; i--, j++)
            {
                returnValue[j] = bitArray[i] == true ? '1' : '0';
            }

            return new string(returnValue);
        }
    }
}
