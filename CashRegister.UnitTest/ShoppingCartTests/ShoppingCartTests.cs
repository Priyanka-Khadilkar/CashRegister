﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.ShoppingCartFactory;
using CashRegister.ProductSellFactory;

namespace CashRegister.UnitTest.ShoppingCartTests
{
    /// <summary>
    /// Summary description for ShoppingCartTests
    /// </summary>
    [TestClass]
    public class ShoppingCartTests
    {
        /// <summary>
        /// Given an empty shoppingcart, it is expected to return 0 as expectedTotalPrice 
        /// </summary>
        [TestMethod]
        public void ShoppingCart_EmptyTest()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();

            //act
            decimal totalPrice = shoppingCart.getTotalPrice();

            // assert
            const decimal expectedTotalPrice = 0m;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        /// <summary>
        /// Give an empty ProductSell, it is expected to return an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "productSell does not contain valid attributes")]
        public void ShoppingCart_AddingInvalidEmptyProductSell()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellTypeFactory productSellFactory = new ProductSellTypeFactory();
            ProductSellByWeight p = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);

            //act
            shoppingCart.add((ProductSell)p);

            // assert
            //Must throw ArgumentOutOfRangeException : productSell does not contain valid attributes
        }

    }
}
