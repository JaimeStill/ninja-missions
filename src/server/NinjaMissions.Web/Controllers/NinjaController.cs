using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NinjaMissions.Data;
using NinjaMissions.Data.Entities;
using NinjaMissions.Data.Extensions;

namespace NinjaMissions.Web.Controllers
{
    [Route("api/[controller]")]
    public class NinjaController : Controller
    {
        private AppDbContext db;

        public NinjaController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<List<Ninja>> GetNinjas() => await db.GetNinjas();

        [HttpGet("[action]/{search}")]
        public async Task<List<Ninja>> SearchNinjas([FromRoute]string search) =>
            await db.SearchNinjas(search);

        [HttpGet("[action]/{name}")]
        public async Task<Ninja> GetNinja([FromRoute]string name) =>
            await db.GetNinja(name);
    }
}