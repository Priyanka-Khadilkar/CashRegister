using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ProductSellFactory
{
    public abstract class ProductSell : Product
    {
        public ProductSell() : base()
        {

        }
        public ProductSell(int productId, string productName, decimal unitPrice) : base(productId, productName, unitPrice)
        {

        }
        public virtual decimal getPrice()
        {
            return 0;
        }
    }
}
