using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Controllers;
using API.Data;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Controllers
{
    [Authorize]
    public class HomeController : BaseApiController
    {
        private readonly DataContext context;
        public HomeController(DataContext context)
        {
            this.context = context;
        }
        
        [HttpGet("tables")]
        [Authorize]
        public async Task<IEnumerable<Table>> getTables()
        {
            return await this.context.Tables.ToListAsync();
        }

        [HttpPut("book")]
        [Authorize(Roles = "Admin")]
        public void BookTable(TableDto tableDto)
        {
            var table = this.context.Tables.Find(tableDto.id);
            table.Available = tableDto.available;
            table.status = tableDto.status;
            this.context.SaveChanges();
        }
    }
}
