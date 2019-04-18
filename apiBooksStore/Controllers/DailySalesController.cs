using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiBooksStore.Data;
using apiBooksStore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiBooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySalesController : ControllerBase
    {
        private readonly BooksStoreContext _context;
        public DailySalesController(BooksStoreContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Monthly sales Report for Book
        /// </summary>
        /// <param name="SalesDate">SalesDate used to get the result text.</param>
        // GET: api/DailySales/5
        [HttpGet("{SalesDate}", Name = "GetDailySales")]
        public IEnumerable<DailySales> GetDailySales(DateTime SalesDate)
        {
           
            List<DailySales> dailySalesquery = (from sales in _context.BookSales
                                                where sales.Quantity > 0 && sales.SaleDate == SalesDate
                                                group sales by sales.BookId into grpSales
                                                select new DailySales
                                                {
                                                    BookId = grpSales.Key,
                                                    DailyTotalSales = grpSales.Sum(s => s.Quantity)
                                                }).ToList();
            dailySalesquery = (from sales in dailySalesquery
                               join books in _context.Books
                             on sales.BookId equals books.BookId
                               select new DailySales
                               {
                                   BookId = sales.BookId,
                                   BookName = books.Title,
                                   DailyTotalSales = sales.DailyTotalSales
                               }).ToList();
            return dailySalesquery;
         
        }

       

      
    }
}
