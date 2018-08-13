using System;
using System.Linq;

namespace DA.SharedKernel
{
    public class Guard
    {
        public static void ForLessEqualZero(long value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
    }
}
