using System;
using System.Collections.Generic;
using System.Linq;

namespace LibKo.Data
{
    public static class StringUtils
    {
        public static string ReverseWords(this string str, char sep)
        {
            char temp;
            var left = 0;
            var middle = 0;

            var chars = str.ToCharArray();
            Array.Reverse(chars);

            for (var i = 0; i <= chars.Length; i++)
            {
                if (i != chars.Length && chars[i] != sep)
                {
                    continue;
                }
                if (left == i || left + 1 == i)
                {
                    left = i + 1;
                    continue;
                }

                middle = (i - left - 1) / 2 + left;

                for (var j = i - 1; j > middle; j--, left++)
                {
                    temp = chars[left];
                    chars[left] = chars[j];
                    chars[j] = temp;
                }

                left = i + 1;
            }

            return new String(chars);
        }

        public static string ReverseWords(this string str)
        {
            return str.ReverseWords(' ');
        }
    }
}
