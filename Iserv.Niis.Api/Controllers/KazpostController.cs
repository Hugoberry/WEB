﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iserv.Niis.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Kazpost")]
    public class KazpostController : Controller
    {
        [HttpGet("byAddress/{query}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string query, int from = 0)
        {
            using (var wc = new WebClient())
            {
                try
                {
                    wc.Encoding = Encoding.UTF8;
                    var response = await wc.DownloadDataTaskAsync($"https://api.post.kz/api/byAddress/{query}?from{from}");

                    return File(response, "application/json;charset=UTF-8");
                }
                finally
                {
                    wc.Dispose();
                }
            }
        }
    }
}