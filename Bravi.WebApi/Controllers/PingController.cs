using AutoMapper;
using Bravi.Data.Database.Models;
using Bravi.WebApi.Controllers.Base;
using Bravi.WebApi.DTO;
using Bravi.WebApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class PingController : ControllerBase
{

    [HttpGet]
    public ActionResult Pong()
    {
        return Ok("pong");
    }

}
