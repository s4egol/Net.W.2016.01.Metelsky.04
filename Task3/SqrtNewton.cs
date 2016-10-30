using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class SqrtNewton
    {
        public static double SqrtN(int n, double number, double eps = 0.00001)
        {
            if ((number < 0) && (n % 2 == 0))
                throw new ArgumentException();
            if (n < 2)
                throw new ArgumentException();
            if ((number == 0) && (n >= 2))
                return 0;

            double x0 = number / n;
            double x1 = (1.0 / n) * ((n - 1) * x0 + number / Math.Pow(x0, n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1.0 / n) * ((n - 1) * x0 + number / Math.Pow(x0, n - 1));
            }

            return Math.Round(x1, 2);
        }
    }
}
