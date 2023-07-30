using AutoMapper;
using Bravi.Data;
using Bravi.Data.Database.Models;
using Bravi.Data.Database.Models.Base;
using Bravi.WebApi.DTO;
using Bravi.WebApi.DTO.Base;
using Bravi.WebApi.Services.Base;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.WebApi.Controllers.Base;

[ApiController]
[Route("[controller]")]
public class GenericCrudController<ControllerClass, Entity, EntityDTO> : ControllerBase
    where ControllerClass : class
    where Entity : EntityBase
    where EntityDTO : EntityBaseDTO
{
    private readonly ILogger<ControllerClass> Logger;
    private readonly IGenericService<Entity> Servico;
    private readonly IMapper Mapper;

    public GenericCrudController(
        ILogger<ControllerClass> logger,
        IGenericService<Entity> pessoaService,
        IMapper mapper
    )
    {
        Logger = logger;
        Servico = pessoaService;
        Mapper = mapper;
    }

    [HttpGet]
    public virtual ActionResult<List<EntityDTO>> Get()
    {
        return Ok(Mapper.Map<IEnumerable<EntityDTO>>(Servico.Get()));
    }
    
    [HttpGet("{id:int}")]
    public virtual ActionResult<EntityDTO> Get(int id)
    {
        return Ok(Mapper.Map<EntityDTO>(Servico.GetByID(id)));
    }

    [HttpPost]
    public virtual ActionResult<EntityDTO> Post([FromBody] EntityDTO entidadeDTO)
    {
        var entidade = Mapper.Map<Entity>(entidadeDTO);
        var entidadeInserida = Servico.Insert(entidade);
        Servico.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = entidade.Id }, Mapper.Map<EntityDTO>(entidadeInserida));
    }

    [HttpPatch("{id:int}")]
    public virtual ActionResult<List<EntityDTO>> Patch(int id, [FromBody] JsonPatchDocument entidadeDTO)
    {
        var entidade = Servico.GetByID(id);
        entidadeDTO.ApplyTo(entidade);
        Servico.Update(entidade);
        Servico.SaveChanges();
        return Ok(entidade);
    }

    [HttpDelete("{id:int}")]
    public virtual ActionResult<List<EntityDTO>> Delete(int id)
    {
        var entidade = Servico.GetByID(id);
        Servico.Delete(entidade);
        Servico.SaveChanges();
        return NoContent();
    }


}
