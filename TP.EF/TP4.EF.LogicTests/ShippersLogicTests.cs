using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TP4.EF.Data;
using TP4.EF.Entities;


namespace TP4.EF.Logic.Tests
{
    [TestClass()]
    public class ShippersLogicTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            // arrange
            ShippersLogic shippersLogic = new ShippersLogic();
            NorthwindContext contexto = new NorthwindContext();
            List<Shippers> listaShippers = contexto.Shippers.ToList();

            // act
            List<Shippers> listado = shippersLogic.GetAll();

            // assert
            for(int i =0;i<listado.Count;i++)
              {
                  Assert.AreEqual<Shippers>(listado[0],listaShippers[0]);
              }
       
        }

        [TestMethod()]
        public void AddTest()
        {
            // arrange
            ShippersLogic shippersLogic = new ShippersLogic();
            Shippers shipperAniadir = new Shippers();
            shipperAniadir.CompanyName = "Test";
            shipperAniadir.Phone= "Test";

            // act
            shippersLogic.Add(shipperAniadir);

            // assert
            List<Shippers> listadoActualizado = shippersLogic.GetAll().ToList();
            Shippers shipperAChequear = listadoActualizado[listadoActualizado.Count() - 1];
            Assert.AreEqual(shipperAniadir, shipperAChequear);

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception),"Id no encontrado")]
        public void DeleteTest()
        {
            // arrange
            ShippersLogic shippersLogic = new ShippersLogic();
            Shippers shipperAniadir = new Shippers();
            shipperAniadir.CompanyName = "Test";
            shipperAniadir.Phone = "Test";
            shippersLogic.Add(shipperAniadir);
            List<Shippers> listadoActualizado = shippersLogic.GetAll().ToList();
            int idShipperAgregado = listadoActualizado[listadoActualizado.Count - 1].ShipperID;

            // act
            shippersLogic.Delete(idShipperAgregado);
            shippersLogic.Busqueda(idShipperAgregado);
            // assert
         

        }

        [TestMethod()]
        public void UpdateTest()
        {
            // arrange
            ShippersLogic shippersLogic = new ShippersLogic();
            List<Shippers> listado = shippersLogic.GetAll().ToList();
            int idShipperAActualizar = listado[listado.Count - 1].ShipperID;

            Shippers shipperUpdate = new Shippers();
            shipperUpdate.ShipperID = idShipperAActualizar;
            shipperUpdate.CompanyName = "Update";
            shipperUpdate.Phone = "Update";

            // act
            shippersLogic.Update(shipperUpdate);

            // assert
            List<Shippers> listadoActualizado = shippersLogic.GetAll().ToList();
            Shippers shipperAChequear = listadoActualizado[listadoActualizado.Count() - 1];
            Assert.AreEqual(shipperUpdate.ShipperID, idShipperAActualizar);
            Assert.AreEqual(shipperUpdate.CompanyName, "Update");
            Assert.AreEqual(shipperUpdate.Phone, "Update");

        }

    }
}