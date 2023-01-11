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

        /// <summary>
        /// Поиск компонентов в БД по тексту, распознанному из изображения предствленного в виде массива байт.
        /// </summary>
        /// <param name="imageData">Массив байт, представляющий изображение</param>
        /// <returns>Модель RecognizedTextResponse</returns>
        Task<RecognizedTextResponse> GetComponentsFromImageData(byte[] imageData);
    }
}
