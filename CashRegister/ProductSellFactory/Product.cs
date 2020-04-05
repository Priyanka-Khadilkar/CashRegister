using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ProductSellFactory
{
    public abstract class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal unitPrice { get; set; }
        public Product()
        {
            productId = 0;
            productName = "Default Name";
            unitPrice = 0;
        }
        public Product(int productId, string productName, decimal unitPrice)
        {
            this.productId = productId;
            this.productName = productName;
            this.unitPrice = unitPrice;
        }
    }
}
