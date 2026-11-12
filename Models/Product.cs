using System;
using System.Collections.Generic;

namespace app_web_ventas.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public int? Supplierid { get; set; }

    public int? Categoryid { get; set; }

    public string? Quantityperunit { get; set; }

    public float? Unitprice { get; set; }

    public int? Unitsinstock { get; set; }

    public int? Unitsonorder { get; set; }

    public int? Reorderlevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Supplier? Supplier { get; set; }
}
