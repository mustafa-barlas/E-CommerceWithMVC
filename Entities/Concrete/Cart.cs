namespace Entities.Concrete;

public class Cart
{
    public List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    public Cart()
    {
        ProductOrders = new List<ProductOrder>();
    }
    
    
    public void AddItem(Product product, int quantity)
    {
        var existingItem = ProductOrders.FirstOrDefault(item => item.Product.ProductId == product.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            ProductOrders.Add(new ProductOrder()
            {
                Product = product, 
                Quantity = quantity,
            });
        }
    }

    public virtual void RemoveLine(Product product)
    {
        var existingItem = ProductOrders.FirstOrDefault(item => item.Product.ProductId == product.ProductId);

        if (existingItem != null)
        {
            if (existingItem.Quantity > 1)
            {
                // Eğer miktar 1'den büyükse, miktarı azalt
                existingItem.Quantity--;
            }
            else
            {
                // Eğer miktar 1 ise, ürünü tamamen sepetten kaldır
                ProductOrders.Remove(existingItem);
            }
        }
    }



    public decimal ComputeTotalValue() => ProductOrders.Sum(x => x.Product.Price.Value * x.Quantity);

    public virtual  void Clear () => ProductOrders.Clear();
}

