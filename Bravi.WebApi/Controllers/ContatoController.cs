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
public class ContatoController : GenericCrudController<ContatoController, Contato, ContatoDTO>
{
    private readonly ILogger<ContatoController> Logger;
    private readonly ContatoService ContatoService;
    private readonly IMapper Mapper;

    public ContatoController(
        ILogger<ContatoController> logger,
        ContatoService ContatoService,
        IMapper mapper
    ) : base ( logger, ContatoService, mapper )
    {
        Logger = logger;
        this.ContatoService = ContatoService;
        this.Mapper = mapper;
    }

}
