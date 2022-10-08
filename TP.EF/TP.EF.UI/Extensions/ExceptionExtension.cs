using System;

namespace TP.EF.UI.Extensions
{
    public static class ExceptionExtension
    {
         public static void ResumenErroresValidacion(this Exception e)
       {
           Console.WriteLine($"Se detectó la siguiente excepción:");

           Console.WriteLine($"\"{e.Message}\"");

           Console.WriteLine("Presione una tecla para intentar nuevamente");

           Console.ReadKey();
       }

    }
}
