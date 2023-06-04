// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Console.WriteLine("Hello, World!");
// Console.Write("First");
// Console.Write("Second");

using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // WHOLE NUMBERS
            // Bytes 8-bit integer signed or unsigned
            // Signed Bytes
            sbyte mySbyte = 127; // Max value possible
            sbyte mySecondSbyte = -128; // Min value possible
            // Unsigned Bytes
            byte myByte = 255; // Max value possible
            byte mySecondByte = 0; // Min value possible

            // Shorts 16-bit integer signed or unsigned
            // Signed short
            short myShort = 32767; // Max value possible
            short mySecondShort = -32768; // Min value possible
            // Unsigned short
            ushort myUshort = 65535; // Max value possible
            ushort mySecondUshort = 0; // Min value possible

            // Ints 32-bit signed value
            int myInt = 2147483647; // Max value possible
            int mySecondInt = -2147483648; // Min value possible

            // Longs 64-bit signed integer
            long myLong = 9223372036854775807; // Max value possible
            long mySecondLong= -9223372036854775808; // Min value possible


            // DECIMALS
            // Float
            float myFloat = 0.751f; // You need  f for float
            float mySecondFloat = 0.75f; // Accuracy issues using floats

            // Doubles
            double myDouble = 0.751; // Doesn't need d
            double mySecondDouble = 0.75d; // You can specify if you want

            // Decimal
            decimal myDecimal = 0.751m; // You need the m
            decimal mySecondDecimal = 0.75m; //

            Console.WriteLine(myFloat - mySecondFloat);
            Console.WriteLine(myDouble - mySecondDouble);
            Console.WriteLine(myDecimal - mySecondDecimal);


            // STRING
            string myString = "new string";
            Console.WriteLine(myString);

            string mySecondString = "!@#@$$!^&*&^%$#";
            Console.WriteLine(mySecondString);

            // BOOLEAN
            bool myBool = true;
            bool mySecondBool = false;
        }
    }
}
