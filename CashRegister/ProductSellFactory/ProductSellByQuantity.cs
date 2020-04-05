using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ProductSellFactory
{
    public class ProductSellByQuantity : ProductSell
    {
        protected int _quantity { get; set; }
        public int quantity { get { return _quantity; } }
        public ProductSellByQuantity() : base()
        {
            _quantity = 0;
        }
        public ProductSellByQuantity(int productId, string productName, decimal unitPrice, int quantity) : base(productId, productName, unitPrice)
        {
            this._quantity = quantity;
        }
        public override decimal getPrice()
        {
            return unitPrice * _quantity;
        }

        public void addQuantity(int quantity)
        {
            this._quantity += quantity;
        }

        public void deductQuantity(int quantity)
        {
            this._quantity -= quantity;
        }

        public void resetQuantity()
        {
            this._quantity = 0;
        }
    }
}
