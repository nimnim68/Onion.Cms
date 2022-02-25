namespace Store.Blazor.Shared.Models.Product
{
    public class ApiProductListResult
    {
        public string Title { get; set; }
        public string Theme { get; set; }
        public ProductInfo[] ProductInfo { get; set; }
    }
}