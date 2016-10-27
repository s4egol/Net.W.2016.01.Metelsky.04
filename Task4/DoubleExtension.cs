using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class DoubleExtension
    {

        public static string ConvertInBinary(this double number)
        {
            const int offset = 1023; //offset for the exponenta sign
            string returnString = String.Empty;

            if (number >= 0)
                returnString = String.Concat("0", returnString);
            else
                returnString = String.Concat("1", returnString);

            var parameters = new Parameters();
            parameters = GetExp(new StringBuilder(ToBinInt(number)), new StringBuilder(ToBinFraction(number)));
            
            if (parameters.exponent < 0)
                returnString = String.Concat(Reverse(ToBinInt(offset - parameters.exponent)), returnString);
            else
                returnString = String.Concat(Reverse(ToBinInt(offset + parameters.exponent)), returnString);

            returnString = String.Concat(Reverse(parameters.mantissa.ToString()), returnString);

            for (int i = 0; i < 64 - returnString.Length; i++)
                returnString = String.Concat("0", returnString);

            return Reverse(returnString);
        }

        private static Parameters GetExp(StringBuilder integerPart, StringBuilder fraction)
        {
            int exp = 0;
            Parameters param = new Parameters();

            bool flag = false;
            for (int i = 0; i < integerPart.Length; i++)
            {
                if (flag)
                    exp++;
                if (integerPart[i] == '1')
                {
                    flag = true;
                }
            }

            if (flag)
            {
                var mantissa = new StringBuilder();
                for (int i = integerPart.Length - exp; i < integerPart.Length; i++)
                {
                    mantissa.Append(integerPart[i]);
                }
                mantissa.Append(fraction);
                param.mantissa = mantissa;
                param.exponent = exp;
                return param;
            }

            for (int i = 0; i < fraction.Length; i++)
            {
                if (fraction[i] == '1')
                {
                    var mantissa = new StringBuilder();
                    for (int j = i; j < fraction.Length; j++)
                    {
                        mantissa.Append(fraction[i]);
                    }
                    param.mantissa = mantissa;
                    param.exponent = -i - 1;
                    return param;
                }
            }

            return param;
        }

        private static string ToBinInt(double value)
        {
            string str = String.Empty;
            value = Math.Abs(Math.Truncate(value));
            if (value == 0)
            {
                return "0";
            }

            while (value > 0)
            {
                str = String.Concat(Convert.ToString(value % 2), str);
                value = Math.Truncate(value / 2);
            }
            return str;
        }

        private static string ToBinFraction(double fraction)
        {
            string returnString = String.Empty;
            int length = 10;
            int valueBit;
            int count = 0;
            fraction = Math.Abs(fraction) - Math.Abs(Math.Truncate(fraction));

            if (fraction == 0)
                return "0";

            while ((count < length) && (fraction != 0.0))
            {
                fraction *= 2;
                valueBit = Convert.ToInt32(Math.Truncate(fraction));
                returnString += Convert.ToString(valueBit);
                fraction -= (double)valueBit;
                count++;
            }
            return returnString;
        }

        private static string Reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }

        private struct Parameters
        {
            public int exponent;
            public StringBuilder mantissa;
        }
    }
}
