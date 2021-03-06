﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.ProductSellFactory;
using CashRegister.ShoppingCartFactory;

namespace CashRegister.UnitTest.ShoppingCartTests
{
    /// <summary>
    /// Summary description for ShoppingCartByCouponTests
    /// </summary>
    [TestClass]
    public class ShoppingCartByCouponTests
    {
        [TestMethod]
        public void ShoppingCartByCoupon_AboveDiscountThreshold()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(5, 50);
            ProductSellTypeFactory productSellFactory = new ProductSellTypeFactory();
            ProductSellByWeight p1 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p1.productId = 124;
            p1.productName = "Apple";
            p1.unitPrice = 2.49m;
            p1.addWeight(2.4m);
            ProductSellByQuantity p2 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 6.99m;
            p2.addQuantity(4);
            ProductSellByQuantityInGroupSell p3 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p3.productId = 312;
            p3.productName = "Body Shampoo";
            p3.unitPrice = 12.99m;
            p3.addQuantity(3);
            p3.discountThreshold = 3;
            ProductSellByQuantityInGroupSell p4 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p4.productId = 312;
            p4.productName = "Body Shampoo";
            p4.unitPrice = 12.99m;
            p4.addQuantity(1);
            p4.discountThreshold = 3;

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            shoppingCart.add((ProductSell)p3);
            shoppingCart.add((ProductSell)p4);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();


            // assert
            const decimal expectedTotalPrice = (2.49m * 2.4m + 6.99m * 4 + 12.99m * 3) - 5;//72.906 -  5 = 67.906
            const int expectedTotalItemNumber = 3;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
            Assert.AreEqual(expectedTotalItemNumber, totalItemNumber);
        }

        [TestMethod]
        public void ShoppingCartByCoupon_BelowDiscountThreshold()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart(5, 100);
            ProductSellTypeFactory productSellFactory = new ProductSellTypeFactory();
            ProductSellByWeight p1 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p1.productId = 124;
            p1.productName = "Apple";
            p1.unitPrice = 2.49m;
            p1.addWeight(2.4m);
            ProductSellByQuantity p2 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 6.99m;
            p2.addQuantity(4);
            ProductSellByQuantityInGroupSell p3 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p3.productId = 312;
            p3.productName = "Body Shampoo";
            p3.unitPrice = 12.99m;
            p3.addQuantity(3);
            p3.discountThreshold = 3;
            ProductSellByQuantityInGroupSell p4 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p4.productId = 312;
            p4.productName = "Body Shampoo";
            p4.unitPrice = 12.99m;
            p4.addQuantity(1);
            p4.discountThreshold = 3;

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            shoppingCart.add((ProductSell)p3);
            shoppingCart.add((ProductSell)p4);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            //72.906 -  0 => 72.906
            // assert
            const decimal expectedTotalPrice = (2.49m * 2.4m + 6.99m * 4 + 12.99m * 3);
            const int expectedTotalItemNumber = 3;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
            Assert.AreEqual(expectedTotalItemNumber, totalItemNumber);
        }

    }
}
