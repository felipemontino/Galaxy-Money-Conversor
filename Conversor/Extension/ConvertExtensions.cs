﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Conversor.Extension
{
    public static class ConvertExtensions
    {
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static string ToRoman(this int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Valor está fora do range de números romanos.");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }

        public static int ToInt(this string numeroRomano)
        {
            int number = 0;
            for (int i = 0; i < numeroRomano.Length; i++)
            {
                if (i + 1 < numeroRomano.Length && RomanMap[numeroRomano[i]] < RomanMap[numeroRomano[i + 1]])
                {
                    number -= RomanMap[numeroRomano[i]];
                }
                else
                {
                    number += RomanMap[numeroRomano[i]];
                }
            }
            return number;
        }
    }
}