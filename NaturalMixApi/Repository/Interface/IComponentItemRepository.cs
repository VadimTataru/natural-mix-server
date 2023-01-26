using NaturalMixApi.Models;

namespace NaturalMixApi.Repository.Interface
{
    public interface IComponentItemRepository
    {
        /// <summary>
        /// Поиск компонентов в БД по входящему списку строк.
        /// </summary>
        /// <param name="components">Список строк</param>
        /// <returns>Модель ComponentItem</returns>
        Task<List<ComponentItem>> GetComponentsInfoAsync(List<string> components);
    }
}
