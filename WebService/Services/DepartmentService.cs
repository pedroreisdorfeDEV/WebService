using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using WebService.Data;
using WebService.Models;
using Microsoft.EntityFrameworkCore; 

namespace WebService.Services
{
    public class DepartmentService
    {
        private readonly WebServiceContext _conetext; 

        public DepartmentService(WebServiceContext context) 
        {
            _conetext = context;
        }

        public async Task<List<Department>> FindAllAsync() 
        {          
            return await _conetext.Department.OrderBy(x => x.Name).ToListAsync();  
        } 
        

        internal void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
