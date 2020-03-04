using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.JWT.Base
{
    [ApiController]
    [Authorize]
    public class SecureController : ControllerBase
    {
    }
}