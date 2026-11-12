namespace app_web_ventas.ViewModel
{
    public class ProductFilterVm
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }
        public bool OnlyAvailable { get; set; }
        public bool? Discontinued { get; set; }
    }
}
