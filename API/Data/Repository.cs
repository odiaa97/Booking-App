using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }
    }
}