using System;
using static System.Console;
namespace CorEscuela.Utils
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 20)
        {
            WriteLine("".PadLeft(tam, '='));
        }

        public static void WriteTitle(string title)
        {
            var dimension = title.Length + 4;
            DibujarLinea(dimension);
            WriteLine($"| {title} |");
            DibujarLinea(dimension);
        }

        public static void Beep(int hz = 2000, int time = 500, int qty = 1)
        {
            while (qty > 0)
            {
                Console.Beep(hz, time);
                qty--;
            }
        }
    }
}