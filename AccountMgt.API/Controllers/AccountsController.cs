using AccountMgt.SERVICE.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IRepoService _repoService;
        public AccountsController(IRepoService repoService)
        {
            _repoService = repoService;
        }


        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repoService.AccountsService.Get());
        }
    }
}
