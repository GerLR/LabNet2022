using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Data;
using TP4.EF.Entities;

namespace TP4.EF.Logic.Tests
{
    [TestClass()]
    public class SuppliersLogicTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            // arrange
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            NorthwindContext contexto = new NorthwindContext();
            List<Suppliers> listaSuppliers = contexto.Suppliers.ToList();

            // act
            List<Suppliers> listado = suppliersLogic.GetAll();

            // assert
            for (int i = 0; i < listado.Count; i++)
            {
                Assert.AreEqual<Suppliers>(listado[0], listaSuppliers[0]);
            }
        }


        [TestMethod()]
        public void AddTest()
        {
            // arrange
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            Suppliers supplierAniadir = new Suppliers();
            supplierAniadir.CompanyName = "Test";
            supplierAniadir.ContactName = "Test1";
            supplierAniadir.ContactTitle= "Test2";

            // act
            suppliersLogic.Add(supplierAniadir);

            // assert
            List<Suppliers> listadoActualizado = suppliersLogic.GetAll().ToList();
            Suppliers suppliersAChequear = listadoActualizado[listadoActualizado.Count() - 1];
            Assert.AreEqual(supplierAniadir, suppliersAChequear);

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Id no encontrado")]
        public void DeleteTest()
        {
            // arrange
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            Suppliers supplierAniadir = new Suppliers();
            supplierAniadir.CompanyName = "Test";
            supplierAniadir.ContactName = "Test1";
            supplierAniadir.ContactTitle = "Test2";
            List<Suppliers> listadoActualizado = suppliersLogic.GetAll().ToList();
            int idSupplierAgregado = listadoActualizado[listadoActualizado.Count - 1].SupplierID;

            // act
            suppliersLogic.Delete(idSupplierAgregado);
            suppliersLogic.Busqueda(idSupplierAgregado);
            // assert
         

        }

        [TestMethod()]
        public void UpdateTest()
        {
            // arrange
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            List<Suppliers> listado = suppliersLogic.GetAll();
            int idSupplierAActualizar = listado[listado.Count - 1].SupplierID;

            Suppliers supplierUpdate = new Suppliers();
            supplierUpdate.SupplierID = idSupplierAActualizar;
            supplierUpdate.CompanyName = "Update";
            supplierUpdate.ContactName = "Update1";
            supplierUpdate.ContactTitle = "Update2";

            // act
            suppliersLogic.Update(supplierUpdate);

            // assert
            List<Suppliers> listadoActualizado = suppliersLogic.GetAll().ToList();
            Suppliers supplierAChequear = listadoActualizado[listadoActualizado.Count() - 1];
            Assert.AreEqual(supplierUpdate.SupplierID, idSupplierAActualizar);
            Assert.AreEqual(supplierUpdate.CompanyName, "Update");
            Assert.AreEqual(supplierUpdate.ContactName, "Update1");
            Assert.AreEqual(supplierUpdate.ContactTitle, "Update2");

        }
    }
}