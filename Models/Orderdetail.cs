using System;
using System.Collections.Generic;

namespace app_web_ventas.Models;

public partial class Orderdetail
{
    public int Orderid { get; set; }

    public int Productid { get; set; }

    public float Unitprice { get; set; }

    public int Quantity { get; set; }

    public float Discount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
