using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EF.UI.Extensions;
using TP4.EF.Entities;
using TP4.EF.Logic;

namespace TP.EF.UI
{
    public static class ConsoleHelper
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenidos a Northwind");
            Console.WriteLine("Seleccionar acción:\n");
            Console.WriteLine("1) Obtener listado de shippers");
            Console.WriteLine("2) Obtener listado de suppliers");
            Console.WriteLine("3) Añadir shipper");
            Console.WriteLine("4) Añadir supplier");
            Console.WriteLine("5) Eliminar shipper");
            Console.WriteLine("6) Eliminar supplier");
            Console.WriteLine("7) Actualizar shipper");
            Console.WriteLine("8) Actualizar supplier");
            Console.WriteLine("9) Finalizar programa");

            switch (Console.ReadLine())
            {
                case "1":
                    ListarShippers();
                    break;
                case "2":
                    ListarSuppliers();
                    break;
                case "3":
                    AniadirShipper();
                    break;
                case "4":
                    AniadirSupplier();
                    break;
                case "5":
                    EliminarShippers();
                    break;
                case "6":
                    EliminarSuppliers();
                    break;
                case "7":
                    ActualizarShipper();
                    break;
                case "8":
                    ActualizarSupplier();
                    break;
                case "9":
                    Console.WriteLine("Aplicación finalizada, presione un botón para continuar");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Valor erróneo, presione una tecla para intentar nuevamente");
                    Console.ReadKey();
                    break;
            }
        }
        public static void ListarShippers()
        {
            ShippersLogic shippersLogic = new ShippersLogic();
            List<Shippers> listado = shippersLogic.GetAll().ToList();
            Console.WriteLine("\n Listado de shippers:");

            foreach (Shippers s in listado)
            {
                Console.WriteLine($"Id: {s.ShipperID}, empresa: {s.CompanyName}, teléfono: {s.Phone}");
            }

            Console.WriteLine("Presione una tecla para retornar al menú principal");
            Console.ReadKey();
        }
        public static void ListarSuppliers()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            List<Suppliers> listado = suppliersLogic.GetAll().ToList();
            Console.WriteLine("\nListado de suppliers:");

            // Se toman 3 propiedades de la entidad suppliers para simplificar el ejemplo

            foreach (Suppliers s in listado)
            {
                Console.WriteLine($"Id: {s.SupplierID}, empresa: {s.CompanyName}, contacto: {s.ContactName}, título del contacto: {s.ContactTitle}");
            }
            Console.WriteLine("Presione una tecla para retornar al menú principal");
            Console.ReadKey();
        }
        public static void AniadirShipper()
        {
            do
            {
                try
                {
                    ShippersLogic shippersLogic = new ShippersLogic();
                    Shippers nuevoShipper = new Shippers();

                    Console.WriteLine("Escriba el nombre de la empresa o ingrese la tecla n para volver al menú:");
                    string readline = Console.ReadLine();
                    if (readline == "n")
                        break;
                    nuevoShipper.CompanyName = readline;

                    Console.WriteLine("Escriba el teléfono de la empresa:");
                    string telefonoEmpresa = Console.ReadLine();
                    nuevoShipper.Phone = telefonoEmpresa;

                    shippersLogic.Add(nuevoShipper);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Shipper añadido, presione una tecla para continuar");

                Console.ReadKey();
                break;
            }
            while (true);

        }
        public static void AniadirSupplier()
        {
            /// Se completan sólo 3 parámetros para simplificar el ejemplo
            /// 
            do
            {
                try
                {
                    SuppliersLogic suppliersLogic = new SuppliersLogic();
                    Suppliers nuevoSupplier = new Suppliers();

                    Console.WriteLine("Escriba el nombre de la empresa o ingrese la tecla n para volver al menú:");
                    string readline = Console.ReadLine();
                    if (readline == "n")
                        break;
                    nuevoSupplier.CompanyName = readline;

                    Console.WriteLine("Escriba el nombre del contacto:");
                    string nombreContacto = Console.ReadLine();
                    nuevoSupplier.ContactName = nombreContacto;

                    Console.WriteLine("Escriba el título del contacto:");
                    string tituloContacto = Console.ReadLine();
                    nuevoSupplier.ContactTitle = tituloContacto;

                    suppliersLogic.Add(nuevoSupplier);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Supplier añadido, presione una tecla para continuar");

                Console.ReadKey();
                break;
            }
            while (true);

        }
        public static void EliminarShippers()
        {
            do
            {
                try
                {
                    ShippersLogic shippersLogic = new ShippersLogic();

                    Console.WriteLine("Indique el Id del shipper a eliminar o ingrese la tecla n para volver al menú:");
                    string readline = Console.ReadLine();
                    if (readline == "n")
                        break;
                    int id = Int32.Parse(readline);
                    shippersLogic.Delete(id);
                }
                catch (OverflowException)
                {
                    Exception e = new Exception("El número indicado es muy grande o muy pequeño");
                    e.ResumenErroresValidacion();
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                Console.WriteLine("Shipper eliminado, presione una tecla para continuar");

                Console.ReadKey();
                break;

            }
            while (true);
        }
        public static void EliminarSuppliers()
        {
            do
            {
                try
                {
                    SuppliersLogic suppliersLogic = new SuppliersLogic();
                    Console.WriteLine("Indique el Id del supplier a eliminar o ingrese la tecla n para volver al menú:");
                    string readline = Console.ReadLine();
                    if (readline == "n")
                        break;
                    int id = Int32.Parse(readline);
                    suppliersLogic.Delete(id);
                }
                catch (OverflowException)
                {
                    Exception e = new Exception("El número indicado es muy grande o muy pequeño");
                    e.ResumenErroresValidacion();
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Supplier eliminado, presione una tecla para continuar");
                Console.ReadKey();
                break;
            }
            while (true);
        }
        public static void ActualizarShipper()
        {
            do
            {
                try
                {
                    ShippersLogic shippersLogic = new ShippersLogic();
                    Console.WriteLine("Indique el Id del shipper a modificar o ingrese la tecla n para volver al menú:");

                    string readline = Console.ReadLine();
                    if (readline == "n")
                        break;
                    int id = Int32.Parse(readline);
                    Shippers shipper = shippersLogic.Busqueda(id);

                    Console.WriteLine("Indique el nuevo nombre del shipper o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoNombre = Console.ReadLine();
                    if (nuevoNombre != "n")
                    {
                        shipper.CompanyName = nuevoNombre;
                    }

                    Console.WriteLine("Indique el nuevo teléfono del shipper o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoTelefono = Console.ReadLine();
                    if (nuevoTelefono != "n")
                    {
                        shipper.Phone = nuevoTelefono;
                    }
                    shippersLogic.Update(shipper);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Shipper modificado, presione una tecla para continuar");
                Console.ReadKey();
                break;

            }
            while (true);

        }
        public static void ActualizarSupplier()
        {
            SuppliersLogic suppliersLogic = new SuppliersLogic();

            do
            {
                try
                {
                    Console.WriteLine("Indique el Id del supplier a modificar o ingrese la tecla n para volver al menú::");

                    string readline = Console.ReadLine();
                    if (readline == "n")
                        break;
                    int id = Int32.Parse(readline);
                    Suppliers supplier = suppliersLogic.Busqueda(id);

                    Console.WriteLine("Indique el nuevo nombre del supplier o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoNombre = Console.ReadLine();
                    if (nuevoNombre != "n")
                    {
                        supplier.CompanyName = nuevoNombre;
                    }

                    Console.WriteLine("Indique el nuevo contacto del supplier o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoContacto = Console.ReadLine();
                    if (nuevoContacto != "n")
                    {
                        supplier.ContactName = nuevoContacto;
                    }

                    Console.WriteLine("Indique el nuevo título del contacto o ingrese la letra n para evitar cargar un nuevo nombre:");

                    string nuevoTitulo = Console.ReadLine();
                    if (nuevoTitulo != "n")
                    {
                        supplier.ContactTitle = nuevoTitulo;
                    }

                    suppliersLogic.Update(supplier);
                }

                catch (DbEntityValidationException e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }
                catch (Exception e)
                {
                    e.ResumenErroresValidacion();
                    continue;
                }

                Console.WriteLine("Supplier modificado, presione una tecla para continuar");

                Console.ReadKey();
                break;

            }


            while (true);
        }
    }
}
