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
    public class MonthlySalesController : ControllerBase
    {
        private readonly BooksStoreContext _context;
        public MonthlySalesController(BooksStoreContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Daily sales Report for Book
        /// </summary>
        /// <param name="SalesDate">SalesDate used to get the result text.</param>
        // GET: api/MonthlySales/2019-02-01
        [HttpGet("{SalesDate}", Name = "GetMonthlySales")]
        public IEnumerable<MonthlySales> GetMonthlySales(DateTime SalesDate)
        {
          
            List<MonthlySales> monthlySalesquery = (from sales in _context.BookSales
                                                where sales.Quantity > 0 && (sales.SaleDate).Date.Month == (SalesDate).Date.Month && (sales.SaleDate).Date.Year == (SalesDate).Date.Year
                                                group sales by sales.BookId into grpSales
                                                select new MonthlySales
                                                {
                                                    BookId = grpSales.Key,
                                                    MonthlyTotalSales = grpSales.Sum(s => s.Quantity)
                                                }).ToList();
            monthlySalesquery = (from sales in monthlySalesquery
                                 join books in _context.Books
                             on sales.BookId equals books.BookId
                               select new MonthlySales
                               {
                                   BookId = sales.BookId,
                                   BookName = books.Title,
                                   MonthlyTotalSales = sales.MonthlyTotalSales
                               }).ToList();
            return monthlySalesquery;
         
        }

       

      
    }
}
