using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLibrary;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary.Tests
{
    [TestClass]
    public class TestInitAndCleanUp
    {
        private ShoppingCart cart;
        private Item item;

        //Запускается перед стартом кажлого тестирующего метода

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Test Initialize");
            item = new Item();
            item.Name = "Unit test Video Lessons";
            item.Quantity = 10;

            cart = new ShoppingCart();
            cart.Add(item);
        }


        //Запускается после завершения каждого тестурующего метода
        [TestCleanup]
        public void TestCleanUp()
        {
            Debug.WriteLine("Test CleanUp");
            cart.Dispose();
        }

        [TestMethod]
        public void ShoppingCart_CheckOut_ConstainsItem()
        {
            CollectionAssert.Contains(cart.Items, item);
        }

        [TestMethod]
        public void ShoppingCart_RemoveItem_Empty()
        {
            int expected = 0;
            cart.Remove(0);
            Assert.AreEqual(expected, cart.Count);
        }
    }
}