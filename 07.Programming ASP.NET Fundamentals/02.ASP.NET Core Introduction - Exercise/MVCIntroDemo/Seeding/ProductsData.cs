namespace MVCIntroDemo.Seeding;

using Models.Product;

public static class ProductsData
{
    public static IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
    {
        new ProductViewModel()
        {
            Id = 1,
            Name = "Cheese",
            Price = 7.00
        },
        new ProductViewModel()
        {
            Id = 2,
            Name = "Ham",
            Price = 5.50
        },
        new ProductViewModel()
        {
            Id = 3,
            Name = "Bread",
            Price = 1.50
        },
    };
}