using Microsoft.EntityFrameworkCore;


namespace models.models
{

    [Keyless]
    public class sp_get_sales_date_predicion
    {
        public string? Companyname { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime PredictedOrder { get; set; }
        
    }
}
