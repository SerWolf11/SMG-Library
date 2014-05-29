using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibKo.Data
{
    public static class StringUtils
    {

        public static string ReverseWords(this string str, char sep)
        {
            char temp;
            int left = 0, middle = 0;

            char[] chars = str.ToCharArray();
            Array.Reverse(chars);

            for (int i = 0; i <= chars.Length; i++)
            {
                if (i != chars.Length && chars[i] != sep)
                    continue;

                if (left == i || left + 1 == i)
                {
                    left = i + 1;
                    continue;
                }

                middle = (i - left - 1) / 2 + left;

                for (int j = i - 1; j > middle; j--, left++)
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
        { return str.ReverseWords(' '); }
    }
}
