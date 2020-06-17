using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductCatalogApi.Repository;

namespace titipnovi_aspnetcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _catalogContext;
        private readonly IOptionsSnapshot<CatalogSettings> _settings;

        public CatalogController(CatalogContext catalogContext, IOptionsSnapshot<CatalogSettings> settings)
        {
            _catalogContext = catalogContext;
            _settings = settings;
            ((DbContext)catalogContext).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes() 
        {
            var items = await _catalogContext.CatalogTypes.ToListAsync();
            return Ok(items);
        }
    }
}