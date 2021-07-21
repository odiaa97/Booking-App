using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
namespace API.Data
{
    public interface IRepository
    {
         public Task<IEnumerable<AppUser>> GetUsers();
    }
}