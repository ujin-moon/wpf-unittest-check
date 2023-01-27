using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary.Tests
{
    [TestClass]
    public class ClassInitAndCleanup
    {
        private static ShoppingCart cart;
        //Запускается перед стартом первого тестирующего метода (один раз)
        //Метод должен быть открытым, статическим и принимать параметры ти

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Debug.WriteLine("Class Initialize");
            Item item = new Item();
            item.Name = "Unit Test";
            item.Quantity = 10;

            cart = new ShoppingCart();
            cart.Add(item);
        }

        //Запускается после завершения последнего тестирующего метода (од
        //Метод должен быть открытым статическим и возвращать void
        [ClassCleanup]

        public static void TestCleanUp()
        {
            Debug.WriteLine("Class CleanUp");
            cart.Dispose();
        }
        [TestMethod]
        public void ShoppingCart_AddToCart()
        {
            int expected = cart.Items.Count + 1;
            cart.Add(new Item() { Name = "Test", Quantity = 1 });
            Assert.AreEqual(expected, cart.Count);
        }
    }
}