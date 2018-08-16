using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

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
                throw new ArgumentException(parameterName);
            }
        }

        public static void ForNull(object @object, string parameterName)
        {
            if(@object is null)
            {
                throw new ArgumentException(parameterName);
            }
        }

        public static void ForEmail(string email, string parameterName)
        {
            try
            {
                var m = new MailAddress(email);                
            }
            catch (FormatException)
            {
                throw new ArgumentException(parameterName);
            }
        }

        public static void ForPhoneNumber(string number, string parameterName)
        {
            var isPhoneNumber=Regex.Match(number, @"^(\+[0-9]{15})$").Success;

            if (!isPhoneNumber)
            {
                throw new ArgumentException(parameterName);
            }
        }
    }
}
