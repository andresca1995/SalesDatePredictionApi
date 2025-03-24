using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace models.models
{
    [Keyless]
    public class sp_get_Orders_for_client
    {
        public int Orderid { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime Shippeddate { get; set; }
        public string? Shipname { get; set; }
        public string? Shipaddress { get; set; }
        public string? Shipcity { get; set; }
        
    }
}
