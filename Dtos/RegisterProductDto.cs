namespace app_web_ventas.Dtos
{
    public class RegisterProductDto
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int supplierid { get; set; }
        public int categoryid { get; set; }
        public string quantityperunit { get; set; }
        public float unitprice { get; set; }
        public int unitsinstock { get; set; }
        public int? unitsonorder { get; set; }
        public int reorderlevel { get; set; }
        public bool discontinued { get; set; }

    }
}
