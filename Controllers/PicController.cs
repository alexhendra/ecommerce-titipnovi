using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace titipnovi_aspnetcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : Controller
    {
        private readonly IHostingEnvironment _env;

        public PicController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetImage(int id)
        {
            var webRoot = _env.WebRootPath;
            var path = Path.Combine(webRoot + "/Pics/", "shoes-" + id + ".png");
            var buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/png");
        }
    }
}