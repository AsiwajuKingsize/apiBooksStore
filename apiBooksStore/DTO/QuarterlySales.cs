using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.DTO
{
    public class QuarterlySales
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int QuarterlyTotalSales { get; set; }
    }
}
