using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    class Program
    {
        static void Main(string[] args)
        {

            List<TransportePublico> Transportes = new List<TransportePublico>();
            int numeros;
            for (int i = 0; i < 5; i++)
            {
                numeros = i + 1;
                Console.WriteLine($"Ingresa la cantidad de pasajeros para el Omnibus {numeros}");
                Omnibus omnibus = new Omnibus(int.Parse(Console.ReadLine()), numeros);

                Transportes.Add(omnibus);
            }


            for (int i = 0; i < 5; i++)
            {
                numeros = i + 1;
                Console.WriteLine($"Ingresa la cantidad de pasajeros para el Taxi {numeros}");

                Taxi taxi = new Taxi(int.Parse(Console.ReadLine()), numeros);

                Transportes.Add(taxi);
            }

            string transport = "";

            foreach (TransportePublico transporte in Transportes)
            {
                transport = transporte.GetType() == typeof(Omnibus) ? "Omnibus" : "Taxi";
                Console.WriteLine($"{transport} {transporte.Numero}: {transporte.Pasajeros} pasajeros");
            }

            Console.ReadKey();

        }

       
    }
}
