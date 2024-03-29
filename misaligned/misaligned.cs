﻿using System;
using System.Diagnostics;

namespace MisalignedSpace
{
    class Misaligned
    {
        static int printColorMap()
        {
            string[] majorColors = GetMajorColor();
            string[] minorColors = GetMinorColor();
            int pairNumber = 0;
            foreach (string majorColor in majorColors)
            {
                foreach (string minorColor in minorColors)
                {
                    string formattedString = StringFormattor(++pairNumber, majorColor, minorColor);
                    PrintOutput(formattedString);
                }
            }
            return pairNumber;
        }
        static string[] GetMajorColor()
        {
            string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
            return majorColors;
        }
        static string[] GetMinorColor()
        {
            string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };
            return minorColors;
        }
        static string StringFormattor(int index, string majorColor, string minorColor)
        {
            return $"{index} {(index >= 10 ? string.Empty : " ")} | \t {majorColor} {(index >= 16 ? string.Empty : "\t")} |  {minorColor}";
        }
        static void PrintOutput(string formattedString)
        {
            Console.WriteLine(formattedString);
        }
        static void Main(string[] args)
        {
            int result = printColorMap();
            Debug.Assert(result == 25);
            int minorColorCount = GetMinorColor().Length;
            Debug.Assert(minorColorCount == 5);
            int majorColorCount = GetMajorColor().Length;
            Debug.Assert(majorColorCount == 5);
            string formattedString = StringFormattor(1, "White", "Blue");
            Debug.Assert(formattedString.Contains("1") 
                         && formattedString.Contains("White")
                         && formattedString.Contains("Blue"));
        }
    }
}
