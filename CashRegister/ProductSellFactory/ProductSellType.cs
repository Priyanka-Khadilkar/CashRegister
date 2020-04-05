using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ProductSellFactory
{
    public enum ProductSellType { byWeight, byQuantity, byQuantityInGroupSell };
    public class ProductSellTypeFactory 
    {
        public ProductSell GetProductSell(ProductSellType type)
        {
            if (type == ProductSellType.byWeight)
                return new ProductSellByWeight();
            else if (type == ProductSellType.byQuantity)
                return new ProductSellByQuantity();
            else if (type == ProductSellType.byQuantityInGroupSell)
                return new ProductSellByQuantityInGroupSell(new ProductSellByQuantity(), 1);
            else
                throw new ArgumentException("Invalid ProductSellType");
        }
    }
}
