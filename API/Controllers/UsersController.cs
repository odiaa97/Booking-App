using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class UsersController : BaseApiController
    {
        private readonly IRepository _repository;

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<AppUser>> getUsers()
        {
            return await _repository.GetUsers();
        }
    }
}