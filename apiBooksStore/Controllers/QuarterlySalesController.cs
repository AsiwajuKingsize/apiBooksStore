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
    public class QuarterlySalesController : ControllerBase
    {
        private readonly BooksStoreContext _context;
        public QuarterlySalesController(BooksStoreContext context)
        {
            _context = context;
        }
        List<int> Firstquarter = new List<int>() { 1,2,3};
        /// <summary>
        /// Get Quarterly sales Report for Book
        /// </summary>
        /// <param name="Quarter">SalesDate used to get the result text.</param>
        ///  <param name="Year">SalesDate used to get the result text.</param>
        // GET: api/DailySales/5
        [HttpGet("{Year}/{Quarter}")]
        public IEnumerable<QuarterlySales> GetQuarterlySales(int Year, int Quarter)
        {
          if (Quarter < 1 && Quarter > 4)
            {
                return null;
            }
            else {
                if (Quarter == 1 )
                {

                    List<QuarterlySales> quaterlySalesquery = (from sales in _context.BookSales
                                                               where sales.Quantity > 0  && ((sales.SaleDate).Date.Year == Year) && ((sales.SaleDate).Date.Month==1 || (sales.SaleDate).Date.Month == 2 || (sales.SaleDate).Date.Month == 3)
                                                               group sales by sales.BookId into grpSales
                                                               select new QuarterlySales
                                                               {
                                                                   BookId = grpSales.Key,
                                                                   QuarterlyTotalSales = grpSales.Sum(s => s.Quantity)
                                                               }).ToList();

                    quaterlySalesquery = (from sales in quaterlySalesquery
                                          join books in _context.Books
                                     on sales.BookId equals books.BookId
                                          select new QuarterlySales
                                          {
                                              BookId = sales.BookId,
                                              BookName = books.Title,
                                              QuarterlyTotalSales = sales.QuarterlyTotalSales
                                          }).ToList();
                    return quaterlySalesquery;
                }
                else if (Quarter == 2)
                {
                    List<QuarterlySales> quaterlySalesquery = (from sales in _context.BookSales
                                                               where sales.Quantity > 0 && ((sales.SaleDate).Date.Year == Year) && ((sales.SaleDate).Date.Month == 4 || (sales.SaleDate).Date.Month == 5 || (sales.SaleDate).Date.Month == 6)
                                                               group sales by sales.BookId into grpSales
                                                               select new QuarterlySales
                                                               {
                                                                   BookId = grpSales.Key,
                                                                   QuarterlyTotalSales = grpSales.Sum(s => s.Quantity)
                                                               }).ToList();

                    quaterlySalesquery = (from sales in quaterlySalesquery
                                          join books in _context.Books
                                     on sales.BookId equals books.BookId
                                          select new QuarterlySales
                                          {
                                              BookId = sales.BookId,
                                              BookName = books.Title,
                                              QuarterlyTotalSales = sales.QuarterlyTotalSales
                                          }).ToList();
                    return quaterlySalesquery;
                }

                else if (Quarter == 3 )
                {
                    List<QuarterlySales> quaterlySalesquery = (from sales in _context.BookSales
                                                               where sales.Quantity > 0 && ((sales.SaleDate).Date.Year == Year) && ((sales.SaleDate).Date.Month == 7 || (sales.SaleDate).Date.Month == 8 || (sales.SaleDate).Date.Month == 9)
                                                               group sales by sales.BookId into grpSales
                                                               select new QuarterlySales
                                                               {
                                                                   BookId = grpSales.Key,
                                                                   QuarterlyTotalSales = grpSales.Sum(s => s.Quantity)
                                                               }).ToList();

                    quaterlySalesquery = (from sales in quaterlySalesquery
                                          join books in _context.Books
                                     on sales.BookId equals books.BookId
                                          select new QuarterlySales
                                          {
                                              BookId = sales.BookId,
                                              BookName = books.Title,
                                              QuarterlyTotalSales = sales.QuarterlyTotalSales
                                          }).ToList();
                    return quaterlySalesquery;
                }

                else
                {
                    List<QuarterlySales> quaterlySalesquery = (from sales in _context.BookSales
                                                               where sales.Quantity > 0 && ((sales.SaleDate).Date.Year == Year) && ((sales.SaleDate).Date.Month == 10 || (sales.SaleDate).Date.Month == 11 || (sales.SaleDate).Date.Month == 12)
                                                               group sales by sales.BookId into grpSales
                                                               select new QuarterlySales
                                                               {
                                                                   BookId = grpSales.Key,
                                                                   QuarterlyTotalSales = grpSales.Sum(s => s.Quantity)
                                                               }).ToList();

                    quaterlySalesquery = (from sales in quaterlySalesquery
                                          join books in _context.Books
                                     on sales.BookId equals books.BookId
                                          select new QuarterlySales
                                          {
                                              BookId = sales.BookId,
                                              BookName = books.Title,
                                              QuarterlyTotalSales = sales.QuarterlyTotalSales
                                          }).ToList();
                    return quaterlySalesquery;
                }

            }
        }

       

      
    }
}
