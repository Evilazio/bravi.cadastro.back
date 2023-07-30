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
public class ContatoTipoController : GenericCrudController<ContatoTipoController, ContatoTipo, ContatoTipoDTO>
{
    private readonly ILogger<ContatoTipoController> Logger;
    private readonly ContatoTipoService ContatoTipoService;
    private readonly IMapper Mapper;

    public ContatoTipoController(
        ILogger<ContatoTipoController> logger,
        ContatoTipoService ContatoTipoService,
        IMapper mapper
    ) : base(logger, ContatoTipoService, mapper)
    {
        Logger = logger;
        this.ContatoTipoService = ContatoTipoService;
        this.Mapper = mapper;
    }

}
