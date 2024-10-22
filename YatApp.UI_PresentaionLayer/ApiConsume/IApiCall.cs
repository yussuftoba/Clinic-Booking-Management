using Dto;

namespace ApiConsume;
public interface IApiCall
{
    Task<IEnumerable<T>> GetAllAsync<T>(string url);
    public Task<T> GetByIdAsync<T>(string url, int? id = null);
    public Task<IEnumerable<T>> GetAllByIdAsync<T>(string url, int? id = null);

    Task<bool> CreateAsync<T>(string url, T entity);
    Task<bool> UpdateAsync<T>(string url, int id, T entity);
    Task<bool> DeleteAsync<T>(string url, int id);
}
