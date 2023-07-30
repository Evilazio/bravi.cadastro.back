using Bravi.Data;

namespace Bravi.WebApi.Services.Base
{
    public interface IGenericService<T> : IRepository<T> where T : class
    {

    }
}
