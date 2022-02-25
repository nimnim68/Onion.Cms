namespace Store.Blazor.Shared.Models.Product
{
    public class ProductInfo
    {
        public string Title { get; set; }
        public string Src { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int? DiscountPercent { get; set; }
    }
}