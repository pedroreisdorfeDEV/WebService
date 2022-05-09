using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Data;
using WebService.Models;

namespace WebService.Services
{
    public class SalesRecordService
    {
        private readonly WebServiceContext _conetext; 

        public SalesRecordService(WebServiceContext context) 
        {
            _conetext = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _conetext.SalesRecord select obj;
           
            if (minDate.HasValue) 
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }                       
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date >= maxDate.Value);
            }
           
            return await result
                .Include(x => x.Seller) 
                .Include(x => x.Seller.Department) 
                .OrderByDescending(x => x.Date) 
                .ToListAsync();
        }

        public async Task<List< IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate) 
        {              
            var result = from obj in _conetext.SalesRecord select obj;
           
            if (minDate.HasValue) 
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }                       
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date >= maxDate.Value);
            }
          
            return await result
                .Include(x => x.Seller) 
                .Include(x => x.Seller.Department) 
                .OrderByDescending(x => x.Date) 
                .GroupBy(x => x.Seller.Department) 
                .ToListAsync();
        }

    }
}
