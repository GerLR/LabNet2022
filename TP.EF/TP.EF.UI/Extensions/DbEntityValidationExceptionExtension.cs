using System;
using System.Data.Entity.Validation;

namespace TP.EF.UI.Extensions
{
    public static class DbEntityValidationExceptionExtension
    {
        public static void ResumenErroresValidacion(this DbEntityValidationException e)
        {
            Console.WriteLine($"Se detectaron la/s siguiente/s excepcion/es:");

            foreach (var entities in e.EntityValidationErrors)
            {
                foreach (var items in entities.ValidationErrors)
                {
                    Console.WriteLine($"\"{items.ErrorMessage.ToString()}\"");
                }
            }

            Console.WriteLine("Presione una tecla para intentar nuevamente");

            Console.ReadKey();
        }

    }
}
