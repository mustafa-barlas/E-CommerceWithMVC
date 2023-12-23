namespace WebUI.Models;

public class FavoriteModel
{
    
    public FavoriteModel(int productId, int userId, string productName)
    {
        ProductId = productId;
        UserId = userId;
        ProductName = productName;
    }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; }
}