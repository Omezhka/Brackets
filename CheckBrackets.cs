using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class CheckBrackets
    {
        // словарик скобок
        private static readonly Dictionary<char, char> bracket = new Dictionary<char, char>()
        {
            {'(',')' },
            {'{','}' },
            {'[',']' }
        };

        /// <summary>
        /// проверка парности скобок
        /// </summary>
        static bool CheckPair(string s) 
        {
            int a1 = 0, a2 = 0, a3 = 0, b1 = 0, b2 = 0, b3 = 0;
           
            foreach (var c in s)
            {
                if (c == '(') { a1++; }
                if (c == ')') { b1++; }
                if (c == '{') { a2++; }
                if (c == '}') { b2++; }
                if (c == '[') { a3++; }
                if (c == ']') { b3++; }
            }

            return (a1==b1)&&(a2==b2)&&(a3==b3); 
        }

        /// <summary>
        /// проверка порядка следования скобок
        /// </summary>
        static bool CheckString(string s, char c, ref int i)
        {
            bool goodString = false;
            bracket.TryGetValue(c, out char endBracket);
            i++;
            while (i < s.Length)
            {
                if (bracket.ContainsValue(s[i])) 
                {
                    if (s[i] == endBracket) { goodString = true; }
                    break; 
                }

                if (bracket.ContainsKey(s[i]))
                {
                    goodString = CheckString(s, s[i], ref i);
                }

                i++;
            }
            if (i == s.Length) { goodString = true; }
            return goodString;
        }


        public static bool Check(string s)
        {
            bool goodString = false;
            int i = 0;

            while (i < s.Length)
            {
                if (bracket.ContainsValue(s[i]))
                {
                    break;
                }
                if (bracket.ContainsKey(s[i]))
                {
                    goodString = CheckString(s, s[i], ref i);
                }
              
                i++;
            }
            return goodString && CheckPair(s);
        }


    }
}
