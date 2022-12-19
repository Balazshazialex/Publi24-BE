using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publi24.Services
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        Task<T> Add(object value);
        T Get(int id);
        T Get(string isin);
        T Put(object value);
    }
}
