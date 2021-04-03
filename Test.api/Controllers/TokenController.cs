using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.logic.Common;
using Test.data;
using Test.data.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Test.data.ViewModels;
using Test.logic;

namespace Test.api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        public TokenController( )
        {

        }


    }
}