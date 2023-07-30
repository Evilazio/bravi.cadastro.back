using Bravi.Data;
using Bravi.Data.Database.Context;
using Bravi.Data.Database.Models;
using Bravi.WebApi.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace Bravi.WebApi.Services
{
    public class PessoaService : GenericService<Pessoa>, IGenericService<Pessoa>
    {
        public PessoaService(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
