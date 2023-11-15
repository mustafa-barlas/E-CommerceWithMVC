namespace Entities.Concrete;

public class Cart
{
    public List<CartLine> Lines { get; set; }

    public Cart()
    {
        Lines = new List<CartLine>();
    }

    public virtual void AddItem(Product product, int quantity)
    {
        CartLine? line = Lines.Where(x => x.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();

        if (line is null)
        {
            Lines.Add(new CartLine()
            {
                Product = product,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public virtual void RemoveLine(Product product) =>
        Lines.RemoveAll(x => x.Product.ProductId.Equals(product.ProductId));

    public decimal ComputeTotalValue() => Lines.Sum(x => x.Product.Price.Value * x.Quantity);

    public virtual  void Clear () => Lines.Clear();
}