using System;
using static System.Console;
namespace CorEscuela.Utils
{
    public static class Printer
    {
        public static void DrawLine(int tam = 20)
        {
            WriteLine("".PadLeft(tam, '='));
        }

        public static void WriteTitle(string title)
        {
            var dimension = title.Length + 4;
            DrawLine(dimension);
            WriteLine($"| {title} |");
            DrawLine(dimension);
        }

        public static void Beep(int hz = 2000, int time = 500, int qty = 1)
        {
            try
            {
                while (qty > 0)
                {
                    Console.Beep(hz, time);
                    qty--;
                }
            }
            catch (PlatformNotSupportedException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public static void PressEnter()
        {
            WriteLine("Presione enter para continuar");
        }

        public static int PrintMenu(string[] options, string menuName)
        {
            WriteTitle(menuName);
            DrawLine(menuName.Length);
            var value = 0;
            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}.- {options[i]}");
                value = i;
            }
            DrawLine();
            WriteLine("Por favor seleccione una opción del Menú para continuar");

            var result = Console.ReadLine();
            if((value+1)>options.Length){
                Console.WriteLine("Menú no valido");
                Console.ReadLine();
            }

            return int.Parse(result);
        }
    }
}