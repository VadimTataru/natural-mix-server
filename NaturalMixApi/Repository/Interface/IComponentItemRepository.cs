using NaturalMixApi.Models;

namespace NaturalMixApi.Repository.Interface
{
    public interface IComponentItemRepository
    {
        Task<IEnumerable<ComponentItem>> GetComponentsInfoAsync(List<string> components);
    }
}
