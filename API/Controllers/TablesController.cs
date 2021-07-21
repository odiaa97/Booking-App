using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TablesController : BaseApiController
    {
        private readonly DataContext dataContext;
        public TablesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<Table> AddTable(Table table)
        {
            this.dataContext.Tables.Add(table);
            await this.dataContext.SaveChangesAsync();
            return table;
        }
    }
}