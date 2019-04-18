using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.DTO
{
    public class DailySales
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int DailyTotalSales { get; set; }
    }
}
