using Bravi.Data;
using Bravi.Data.Database.Context;
using Bravi.Data.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Bravi.WebApi.Services.Base
{
    public abstract class GenericService<T> : Repository<T> where T : class
    {
        public GenericService(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
